namespace Plays_Downloader
{
    partial class startup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startup));
            this.start = new System.Windows.Forms.Timer(this.components);
            this.st = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Interval = 1000;
            this.start.Tick += new System.EventHandler(this.start_Tick);
            // 
            // st
            // 
            this.st.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.st.Location = new System.Drawing.Point(12, 9);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(432, 133);
            this.st.TabIndex = 2;
            this.st.Text = "Starting...";
            this.st.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st.MouseDown += new System.Windows.Forms.MouseEventHandler(this.st_MouseDown);
            // 
            // startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(456, 151);
            this.Controls.Add(this.st);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.startup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.startup_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startup_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer start;
        private System.Windows.Forms.Label st;
    }
}