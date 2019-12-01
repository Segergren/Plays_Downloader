using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

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

            //Wait to make sure Firefox folder is 100% downloaded
            System.Threading.Thread.Sleep(2000);

            //Opens main window
            this.Hide();
            Plays sistema = new Plays();
            sistema.ShowDialog();
            this.Close();
        }
    }
}
