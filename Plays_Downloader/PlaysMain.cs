using Gecko;
using Gecko.DOM;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plays_Downloader
{
    public partial class Plays : Form
    {
        public Plays()
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

        /* Sound dll */
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr h, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr h, uint dwVolume);
        

        //Varibles
        bool continuenow = false;
        bool publiconly = false;
        GeckoWebBrowser geckoWebBrowser = new GeckoWebBrowser();
        bool done1 = false;
        bool done2 = false;
        bool done3 = false;
        bool done4 = false;
        string sort = "";
        int curdown = 0;
        /* EXTRA INFORMATION FOR DID YOU KNOW */
        double infoclipseconds = 0;
        int infoviews = 0;
        int infocomments = 0;
        DateTime infofirstplays = new DateTime();
        /* END */
        double downloaded = 0;
        double downloadeddone = 0;
        string path = "";
        int infoCounter = 0;
        int videosfound = 0;
        private void loginTimer_Tick(object sender, EventArgs e)
        {
            //Checks if the user is logged in or not
            GeckoNodeCollection links = geckoWebBrowser.Document.GetElementsByClassName("show-user-menu");
            int count = 0;
            foreach (GeckoElement link in links)
            {
                count++;
            }
            if (count > 0)
            {
                loginTimer.Stop();
                Downloadbtn.Enabled = true;
            }
        }

        private void setTextSafe(string txt)
        {
            if (downloadingrn.InvokeRequired)
                downloadingrn.Invoke(new Action(() => downloadingrn.Text = txt));
            else
                downloadingrn.Text = txt;
        }


        private void Plays_Load(object sender, EventArgs e)
        {
            //Starts the Gecko browser
            Xpcom.Initialize("Firefox");
            geckoWebBrowser = new GeckoWebBrowser
            {
                Dock = System.Windows.Forms.DockStyle.Bottom,
                Location = new System.Drawing.Point(0, 0),
                MinimumSize = new System.Drawing.Size(479, 293),
                Name = "geckoBrowser",
                Size = new System.Drawing.Size(479, 293),
                MaximumSize = new System.Drawing.Size(479, 293),
                TabIndex = 1
            };

            //Hides the browser for the end user
            this.Controls.Add(geckoWebBrowser);
            geckoWebBrowser.Hide();

            //Deletes the temp file
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "temporary.zip");

            //Starts the process
            Load0SiteAsync();           
        }

        private async Task Load0SiteAsync()
        {
            geckoWebBrowser.Navigate("https://plays.tv/logout");
            await PutTaskDelay(2000);
            geckoWebBrowser.Navigate("https://plays.tv/login");
        }


        private async Task Load1SiteAsync()
        {
            //Navigates to the homescreen and sets a SAFE delay
            await PutTaskDelay(5000);
            geckoWebBrowser.Navigate("https://plays.tv/home");
            done1 = true;
            await PutTaskDelay(5000);

            //Checks if the user is logged in or not
            GeckoNodeCollection links = geckoWebBrowser.Document.GetElementsByClassName("avatar");
            string linkredirect = "";
            foreach (GeckoElement link in links)
            {
                try
                {
                    if (link.GetAttribute("href").Length > 0)
                    {
                        linkredirect = link.GetAttribute("href");
                    }
                }
                catch
                {

                }
            }
            if (linkredirect == "")
            {
                MessageBox.Show("Wrong Username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Restarts the program, because otherwise the geckoWebBrowser bugs
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close();
            }

            //Redirects to users home video
            geckoWebBrowser.Navigate("https://plays.tv" + linkredirect);
            await PutTaskDelay(5000);
            done2 = true;

            //Gets users ID
            GeckoElement VideoJSONtemp = (GeckoElement)geckoWebBrowser.Document.GetElementsByClassName("full-width header-profile")[0];
            string JSON = Convert.ToString(VideoJSONtemp.GetAttribute("data-conf"));
            dynamic details = JValue.Parse(JSON);

            //Navigates to the JSON file (With a webclient the JSON would only show published videos)
            geckoWebBrowser.Navigate("https://plays.tv/playsapi/feedsys/v1/userfeed/" + details.login_user.id + "/uploaded?limit=999999");
            await PutTaskDelay(5000);

            string JSONformated = "";
            int retrying = 0;
            while (retrying < 10)
            {
                //Tries to get the JSON, you need to be logged in to get unlisted videos
                try
                {
                    string JSONunformated = geckoWebBrowser.Document.Body.OuterHtml;
                    if (!JSONunformated.Contains("</pre></body>"))
                    {
                        retrying++;
                        setTextSafe("Retrying: " + retrying + "/10");
                        await PutTaskDelay(3500);
                    }
                    else
                    {
                        JSONformated = JSONunformated.Replace("</pre></body>", "").Replace("<body><pre>", "");
                        break;
                    }
                }
                catch
                {
                    retrying++;
                    setTextSafe("Retrying: " + retrying + "/10");
                    await PutTaskDelay(3500);
                }
            }
            if (retrying > 10)
            {
                MessageBox.Show("Can't access Plays.TV api...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                this.Close();
            }

            //Gets the JSON from Plays api
            dynamic videoJSON = JValue.Parse(JSONformated);
            JArray items = (JArray)videoJSON["items"];

            //Creates a list that hold video information
            List<string> nameList = new List<string>();
            List<string> downloadlinkList = new List<string>();
            List<string> typeList = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                dynamic item = (JObject)items[i];
                bool unlisted = item.unlisted;

                //Get video information
                string name = item.description;
                string downloadlink = item.downloadUrl;
                string type = item.type;
                if ((dntscreenshots.Checked == true) && (type.Contains("image") == true))
                {

                }
                else
                {
                    if (unlisted == true && publiconly == true)
                    {

                    }
                    else
                    {
                        nameList.Add(name);
                        downloadlinkList.Add(downloadlink);
                        typeList.Add(type);
                    }
                }

                //Inserts information to Did you know
                JObject res = (JObject)items[i];
                double secc = Convert.ToDouble(item.duration);
                infoclipseconds += Convert.ToDouble(secc);
                infoviews += (int)res["stats"]["clicks"];
                infocomments += (int)res["stats"]["comments"];
                double dateUnix = Convert.ToDouble(Convert.ToString(item.created).Replace("000", ""));
                infofirstplays = UnixTimeStampToDateTime(dateUnix);

            }
            //Adds the total videos the a integer that the end user will see
            videosfound = nameList.Count;

            done3 = true;

            //First did you know
            Infotimer.Start();
            infolbl.Text = "Did you know:";
            infolbl.Show();
            didyouknow.Text = "The first Plays.tv video was uploaded 03/09/2015 by Plays";
            didyouknow.Show();

            for (int i = 0; i < nameList.Count; i++)
            {
                curdown = i;

                //Adds SORT BY DATE
                if (rbUD.Checked)
                {
                    sort = "[" + (i + 1) + "] ";
                }

                //Gets current video information
                string name = Convert.ToString(nameList[i]);
                string downloadlink = Convert.ToString(downloadlinkList[i]);
                string type = Convert.ToString(typeList[i]);

                //Replaces bad names
                Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
                name = illegalInFileName.Replace(name, "_");

                //Checks if it's an image or not
                if (type == "image")
                {
                    if (incscreenshots.Checked == true)
                    {
                        DownloadFile(downloadlink, path + @"\" + sort + name + ".jpeg");
                    }
                }
                else
                {
                    DownloadFile(downloadlink, path + @"\" + sort + name + ".mp4");
                }

                await PutTaskDelay(3500);
            }
        }

        //DOWNLOADING VOIDS
        private volatile bool _completed;
        public void DownloadFile(string address, string location)
        {
            WebClient client = new WebClient();
            Uri Uri = new Uri(address);
            _completed = false;

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            client.DownloadFileAsync(Uri, location);

        }

        public bool DownloadCompleted { get { return _completed; } }

        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            downloaded = ConvertBytesToMegabytes(e.BytesReceived);
            downloadeddone = ConvertBytesToMegabytes(e.TotalBytesToReceive);
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            _completed = true;
        }

        //Puts a delay
        async Task PutTaskDelay(int timemilliseconds)
        {
            await Task.Delay(timemilliseconds);
        }

        private void Downloadbtn_Click(object sender, EventArgs e)
        {
            //Shows "Public only" and "Public and unlisted" buttons
            if (path.Length != 0)
            {
                pandu.Show();
                ponly.Show();
            }
            else
            {
                MessageBox.Show("Please select a folder where the videos will be saved to.", "Select a folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void donetimer_Tick(object sender, EventArgs e)
        {
            /* Updates the process for the end user */

            //Set volume to Zero, otherwise the user will hear Plays.tv in the background because of gecko
            waveOutSetVolume(IntPtr.Zero, 0);


            if (done4)
            {
                //DONE
                Infotimer.Stop();
                donetimer.Stop();
                step4.ForeColor = Color.Lime;
                loadingind.Image = Properties.Resources.checkmark_96px;
                downloadingrn.Visible = true;
                downloadingrn.Text = "Done!";
                infolbl.Show();
                infolbl.Text = "Please consider donating if you support this project";
                didyouknow.Hide();
                paypal.Show();
                geckoWebBrowser.Dispose();
            }
            else if (done3)
            {
                //Stage 3
                if (videosfound != 0 && continuenow == false)
                {
                    continuenow = true;
                }
                else
                {
                    step3.ForeColor = Color.Lime;
                    downloadingrn.Visible = true;
                    downloadingrn.Text = "Downloading: " + (curdown + 1) + "/" + videosfound;

                    if ((curdown == videosfound - 1) && (Math.Round(downloadeddone) == Math.Round(downloaded)))
                    {
                        done4 = true;
                    }
                }

            }
            else if (done2)
            {
                //Stage 2
                step2.ForeColor = Color.Lime;
                downloadingrn.Visible = true;
                if (!downloadingrn.Text.Contains("Retrying:"))
                    downloadingrn.Text = "Loading...";
            }
            else if (done1)
            {
                //Stage 1
                step1.ForeColor = Color.Lime;
                downloadingrn.Visible = true;
                downloadingrn.Text = "Logging in...";
            }

        }

        private void closebtn_Click(object sender, EventArgs e)
        {

            /* Removes the firefox folder after the user closed the program */
            string batchCommands = string.Empty;
            string exeFileName = AppDomain.CurrentDomain.BaseDirectory + "Firefox";

            batchCommands += "@ECHO OFF\n";
            batchCommands += "ping 127.0.0.1 > nul\n";
            batchCommands += "echo j | rmdir \"";
            batchCommands += exeFileName + "\" /s /q \n";
            batchCommands += "echo j | del /a \"%~f0\"";

            File.WriteAllText("delext.bat", batchCommands);
            FileInfo FileInfo = new FileInfo("delext.bat");

            FileInfo.Attributes |= FileAttributes.Hidden;
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "delext.bat";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            Environment.Exit(0);
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            //Minimizes the window
            this.WindowState = FormWindowState.Minimized;
        }

        private void Plays_MouseDown(object sender, MouseEventArgs e)
        {
            //Makes it possible for the user to move the window
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void st_MouseDown(object sender, MouseEventArgs e)
        {
            //Makes it possible for the user to move the window
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void folderpicker_Click(object sender, EventArgs e)
        {
            //User selects the folder
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                    folderpicker.Hide();
                }
            }
        }

        private void Plays_Paint(object sender, PaintEventArgs e)
        {
            //Render the blue borders
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(20, 179, 178), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        private void ponly_Click(object sender, EventArgs e)
        {
            //Public only
            publiconly = true;
            Start();
        }

        private void pandu_Click(object sender, EventArgs e)
        {
            //Public and Unlisted
            publiconly = false;
            Start();
        }
        public void Start()
        {
            //Hide radiobuttons
            pandu.Hide();
            ponly.Hide();

            incscreenshots.Hide();
            dntscreenshots.Hide();

            //Login
            geckoWebBrowser.Document.GetElementById("login_urlname").SetAttribute("value", usernametb.Text);
            geckoWebBrowser.Document.GetElementById("login_pwd").SetAttribute("value", passwordtb.Text);
            GeckoButtonElement button = new GeckoButtonElement(geckoWebBrowser.Document.GetElementsByClassName("btn")[1].DomObject);
            button.Click();

            //Hide remaining elements
            Downloadbtn.Hide();
            usernametb.Hide();
            passwordtb.Hide();
            usernamelbl.Hide();
            passwordlbl.Hide();
            folderpicker.Hide();
            rbUD.Hide();
            rbName.Hide();

            //Show loading circle
            loadingind.Show();

            //Starting to load videos
            Load1SiteAsync();

        }

        private void paypal_Click(object sender, EventArgs e)
        {
            //Opens a web browser
            Process.Start("https://paypal.me/pools/c/8kcQQ0UEhm");
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            //Converts Unix time to Date
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        private void Infotimer_Tick(object sender, EventArgs e)
        {
            /* Updates the "Did you know" text */

            if (infoCounter == 0){
                didyouknow.Text = "You have " + Math.Round(infoclipseconds / 60) + " minutes worth of clips";
            }
            else if (infoCounter == 1){
                didyouknow.Text = "You have a total of " + infoviews + " views across all " + videosfound + " videos";
            }
            else if (infoCounter == 2){
                didyouknow.Text = "You have a total of " + infocomments + " comments across all " + videosfound + " videos";
            }

            else if (infoCounter == 3)
            {
                string timeposted = "";
                if (infofirstplays.Date.Hour >= 0 && infofirstplays.Date.Hour <= 5){
                    timeposted = "in the middle of the night in " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(infofirstplays.Date.Month);
                }
                else if (infofirstplays.Date.Hour >= 6 && infofirstplays.Date.Hour <= 9){
                    timeposted = "early as fuck on a " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(infofirstplays.Date.Month) + " morning";
                }
                else if (infofirstplays.Date.Hour >= 10 && infofirstplays.Date.Hour <= 14){
                    timeposted = "in the middle of the day in " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(infofirstplays.Date.Month);
                }
                else if (infofirstplays.Date.Hour >= 15 && infofirstplays.Date.Hour <= 17){
                    timeposted = "a afternoon in " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(infofirstplays.Date.Month);
                }
                else if (infofirstplays.Date.Hour >= 18 && infofirstplays.Date.Hour <= 23){
                    timeposted = "on a " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(infofirstplays.Date.Month) + " evening";
                }
                didyouknow.Text = "You posted your first video " + timeposted;
            }

            else if (infoCounter == 4){
                didyouknow.Text = "Plays was founded 19/12/2016";
            }
            else if (infoCounter == 5){
                didyouknow.Text = "Plays was built by Raptr";
            }
            else if (infoCounter == 6){
                didyouknow.Text = "The first Plays.tv video was uploaded 03/09/2015 by Plays";
            }
            else if (infoCounter == 7){
                didyouknow.Text = "Plays was made in the US";
            }
            else if (infoCounter == 8){
                didyouknow.Text = "Plays had about 10-50 developers";
            }
            if (infoCounter == 8){
                infoCounter = 0;
            }
            else{
                infoCounter++;
            }

        }
    }
}
