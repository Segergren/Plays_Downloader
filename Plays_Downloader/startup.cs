using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Plays_Downloader
{
    public partial class startup : Form
    {
        public startup()
        {
            InitializeComponent();
        }
        /* Move window */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        /* END move window */

        private void startup_Paint(object sender, PaintEventArgs e)
        {
            //Blue corners
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(20, 179, 178), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        private void startup_MouseDown(object sender, MouseEventArgs e)
        {
            //Makes it possible to move the window
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void st_MouseDown(object sender, MouseEventArgs e)
        {
            //Makes it possible to move the window
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void start_Tick(object sender, EventArgs e)
        {
            /* This timer make sure the window to load for the user */
            start.Stop();

            /* Installs geckoBrowser */
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temporary.zip")))
            {
                File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temporary.zip"), Properties.Resources.Firefox);
            }
            FileInfo FileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temporary.zip"));
            FileInfo.Attributes |= FileAttributes.Hidden;

            if (Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firefox")))
            {
                try
                {
                    Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firefox"), true);
                }
                catch
                {
                }
            }

            System.Threading.Thread.Sleep(1000);
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firefox")))
                ZipFile.ExtractToDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temporary.zip"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firefox"));

            DirectoryInfo di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firefox"));
            
            //See if directory has hidden flag, if not, make hidden
            if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                //Add Hidden flag                 
                di.Attributes |= FileAttributes.Hidden;
            }
            /* END install */
            long FolderSize = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

            //Check if the Firefox folder is extracted
            int tries = 0; 
            while (FolderSize != 70813153) //70813153
            {
                if(tries == 200)
                {
                    MessageBox.Show("Can't install needed libraries, try to disable your Anti-virus software.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                System.Threading.Thread.Sleep(100);
                tries++;
            }
            

            //Opens main window
            this.Hide();
            Plays sistema = new Plays();
            sistema.ShowDialog();
            this.Close();
        }
        
        private void startup_Load(object sender, EventArgs e)
        {
            SearchForUpdate("https://api.github.com/repos/O11Software/Plays_Downloader/releases");
        }

        private void SearchForUpdate(string GithubProfileLink)
        {
            //Checks for an update
            //https://api.github.com/repos/O11Software/X/releases
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = "v" + fvi.FileMajorPart + "." + fvi.FileMinorPart + "." + fvi.FileBuildPart;

            //Gets the latest update
            string JSONInfoUnformated = GetReleases(GithubProfileLink);
            JArray JSONInfoformated = JArray.Parse(JSONInfoUnformated);
            string LatestVersion = (string)JSONInfoformated[0]["tag_name"];

            GithubProfileLink = (string)JSONInfoformated[0]["assets_url"];
            JSONInfoUnformated = GetReleases(GithubProfileLink);
            JSONInfoformated = JArray.Parse(JSONInfoUnformated);
            string DownloadLink = (string)JSONInfoformated[0]["browser_download_url"];
            

            //If there is a new update available
            if (LatestVersion != version)
            {
                MessageBox.Show("There is an update available! Click OK to update\nYour version: " + version + "\nNew version: " + LatestVersion ,"New update!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(DownloadLink);
                Environment.Exit(0);
                //UpdateSoftware(GithubProfileLink);
            }
            else
            {
                start.Start();
            }
        }

        /*private void UpdateSoftware(string GithubProfileLink)
        {
            //Updates the software

            
            //var fileName = Path.GetTempPath() + @"\O11SoftwareUpdateInfo";
            //System.IO.File.WriteAllText(fileName, GithubProfileLink + "\n" + Application.ExecutablePath);
            
            string JSONInfoUnformated = GetReleases("https://api.github.com/repos/O11Software/O11Software_Updater/releases");
            JArray JSONInfoformated = JArray.Parse(JSONInfoUnformated);
            string Asset = (string)JSONInfoformated[0]["assets_url"];

            
            JSONInfoUnformated = GetReleases(Asset);
            JSONInfoformated = JArray.Parse(JSONInfoUnformated);
            string UpdateDownloadLink = (string)JSONInfoformated[0]["browser_download_url"];
            Process.Start(UpdateDownloadLink);
            Environment.Exit(0);
            
            string UpdateEXELocation = Path.GetTempPath() + @"\O11Updater.exe";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(UpdateDownloadLink, UpdateEXELocation);
            }
            try
            {
                Process.Start(UpdateEXELocation);
            }
            catch
            {
                Process proc = new Process();
                proc.StartInfo.FileName = UpdateEXELocation;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
            }            
            
        }*/

        private string GetReleases(string GithubProfileLink)
        {
            string GITHUB_API = GithubProfileLink;
            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent", "Unity web player");
            Uri uri = new Uri(string.Format(GITHUB_API));
            string releases = webClient.DownloadString(uri);
            return releases;
        }
    }
}
