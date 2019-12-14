namespace Plays_Downloader
{
    partial class Plays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plays));
            this.Downloadbtn = new System.Windows.Forms.Button();
            this.loginTimer = new System.Windows.Forms.Timer(this.components);
            this.st = new System.Windows.Forms.Label();
            this.step1 = new System.Windows.Forms.Label();
            this.step2 = new System.Windows.Forms.Label();
            this.step3 = new System.Windows.Forms.Label();
            this.step4 = new System.Windows.Forms.Label();
            this.usernametb = new System.Windows.Forms.TextBox();
            this.passwordtb = new System.Windows.Forms.TextBox();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.donetimer = new System.Windows.Forms.Timer(this.components);
            this.downloadingrn = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.PictureBox();
            this.minimizebtn = new System.Windows.Forms.PictureBox();
            this.folderpicker = new System.Windows.Forms.PictureBox();
            this.folderdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.loadingind = new System.Windows.Forms.PictureBox();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbUD = new System.Windows.Forms.RadioButton();
            this.ponly = new System.Windows.Forms.Button();
            this.pandu = new System.Windows.Forms.Button();
            this.sortPanel = new System.Windows.Forms.Panel();
            this.paranthesiscbx = new System.Windows.Forms.CheckBox();
            this.incDate = new System.Windows.Forms.CheckBox();
            this.screenshotPanel = new System.Windows.Forms.Panel();
            this.includeGameFolders = new System.Windows.Forms.CheckBox();
            this.incscreenshots = new System.Windows.Forms.RadioButton();
            this.dntscreenshots = new System.Windows.Forms.RadioButton();
            this.logo = new System.Windows.Forms.PictureBox();
            this.paypal = new System.Windows.Forms.PictureBox();
            this.infolbl = new System.Windows.Forms.Label();
            this.Infotimer = new System.Windows.Forms.Timer(this.components);
            this.didyouknow = new System.Windows.Forms.Label();
            this.connected = new System.Windows.Forms.Timer(this.components);
            this.Refresher = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderpicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingind)).BeginInit();
            this.sortPanel.SuspendLayout();
            this.screenshotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paypal)).BeginInit();
            this.SuspendLayout();
            // 
            // Downloadbtn
            // 
            this.Downloadbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.Downloadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Downloadbtn.Location = new System.Drawing.Point(163, 316);
            this.Downloadbtn.Name = "Downloadbtn";
            this.Downloadbtn.Size = new System.Drawing.Size(198, 42);
            this.Downloadbtn.TabIndex = 3;
            this.Downloadbtn.Text = "Login";
            this.Downloadbtn.UseVisualStyleBackColor = false;
            this.Downloadbtn.Click += new System.EventHandler(this.Downloadbtn_Click);
            // 
            // loginTimer
            // 
            this.loginTimer.Enabled = true;
            this.loginTimer.Interval = 1000;
            this.loginTimer.Tick += new System.EventHandler(this.loginTimer_Tick);
            // 
            // st
            // 
            this.st.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.st.Location = new System.Drawing.Point(212, 9);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(100, 47);
            this.st.TabIndex = 1;
            this.st.Text = "Step";
            this.st.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st.MouseDown += new System.Windows.Forms.MouseEventHandler(this.st_MouseDown);
            // 
            // step1
            // 
            this.step1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.step1.Location = new System.Drawing.Point(119, 59);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(67, 47);
            this.step1.TabIndex = 2;
            this.step1.Text = "1";
            this.step1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // step2
            // 
            this.step2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.step2.Location = new System.Drawing.Point(192, 59);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(67, 47);
            this.step2.TabIndex = 3;
            this.step2.Text = "2";
            this.step2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // step3
            // 
            this.step3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.step3.Location = new System.Drawing.Point(265, 59);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(67, 47);
            this.step3.TabIndex = 4;
            this.step3.Text = "3";
            this.step3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // step4
            // 
            this.step4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.step4.Location = new System.Drawing.Point(338, 59);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(67, 47);
            this.step4.TabIndex = 5;
            this.step4.Text = "4";
            this.step4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernametb
            // 
            this.usernametb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametb.Location = new System.Drawing.Point(163, 174);
            this.usernametb.Name = "usernametb";
            this.usernametb.Size = new System.Drawing.Size(198, 29);
            this.usernametb.TabIndex = 1;
            // 
            // passwordtb
            // 
            this.passwordtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtb.Location = new System.Drawing.Point(163, 268);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.Size = new System.Drawing.Size(198, 29);
            this.passwordtb.TabIndex = 2;
            this.passwordtb.UseSystemPasswordChar = true;
            // 
            // usernamelbl
            // 
            this.usernamelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.usernamelbl.Location = new System.Drawing.Point(164, 124);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(196, 47);
            this.usernamelbl.TabIndex = 8;
            this.usernamelbl.Text = "Username";
            this.usernamelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordlbl
            // 
            this.passwordlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.passwordlbl.Location = new System.Drawing.Point(163, 218);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(198, 47);
            this.passwordlbl.TabIndex = 9;
            this.passwordlbl.Text = "Password";
            this.passwordlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // donetimer
            // 
            this.donetimer.Enabled = true;
            this.donetimer.Interval = 1000;
            this.donetimer.Tick += new System.EventHandler(this.donetimer_Tick);
            // 
            // downloadingrn
            // 
            this.downloadingrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadingrn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.downloadingrn.Location = new System.Drawing.Point(12, 124);
            this.downloadingrn.Name = "downloadingrn";
            this.downloadingrn.Size = new System.Drawing.Size(501, 47);
            this.downloadingrn.TabIndex = 10;
            this.downloadingrn.Text = "0/0";
            this.downloadingrn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadingrn.Visible = false;
            // 
            // closebtn
            // 
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.Image = ((System.Drawing.Image)(resources.GetObject("closebtn.Image")));
            this.closebtn.Location = new System.Drawing.Point(486, 1);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(38, 37);
            this.closebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closebtn.TabIndex = 11;
            this.closebtn.TabStop = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // minimizebtn
            // 
            this.minimizebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizebtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizebtn.Image")));
            this.minimizebtn.Location = new System.Drawing.Point(442, 1);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(38, 37);
            this.minimizebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizebtn.TabIndex = 12;
            this.minimizebtn.TabStop = false;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // folderpicker
            // 
            this.folderpicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.folderpicker.Image = ((System.Drawing.Image)(resources.GetObject("folderpicker.Image")));
            this.folderpicker.Location = new System.Drawing.Point(243, 364);
            this.folderpicker.Name = "folderpicker";
            this.folderpicker.Size = new System.Drawing.Size(38, 42);
            this.folderpicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.folderpicker.TabIndex = 13;
            this.folderpicker.TabStop = false;
            this.folderpicker.Click += new System.EventHandler(this.folderpicker_Click);
            // 
            // loadingind
            // 
            this.loadingind.Image = ((System.Drawing.Image)(resources.GetObject("loadingind.Image")));
            this.loadingind.Location = new System.Drawing.Point(214, 174);
            this.loadingind.Name = "loadingind";
            this.loadingind.Size = new System.Drawing.Size(96, 96);
            this.loadingind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingind.TabIndex = 14;
            this.loadingind.TabStop = false;
            this.loadingind.Visible = false;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.rbName.Location = new System.Drawing.Point(3, 0);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(92, 17);
            this.rbName.TabIndex = 15;
            this.rbName.TabStop = true;
            this.rbName.Text = "Sort by NAME";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbUD
            // 
            this.rbUD.AutoSize = true;
            this.rbUD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.rbUD.Location = new System.Drawing.Point(3, 23);
            this.rbUD.Name = "rbUD";
            this.rbUD.Size = new System.Drawing.Size(137, 17);
            this.rbUD.TabIndex = 16;
            this.rbUD.Text = "Sort by UPLOAD DATE";
            this.rbUD.UseVisualStyleBackColor = true;
            // 
            // ponly
            // 
            this.ponly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.ponly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ponly.ForeColor = System.Drawing.Color.Black;
            this.ponly.Location = new System.Drawing.Point(163, 363);
            this.ponly.Name = "ponly";
            this.ponly.Size = new System.Drawing.Size(198, 42);
            this.ponly.TabIndex = 17;
            this.ponly.Text = "Public only";
            this.ponly.UseVisualStyleBackColor = false;
            this.ponly.Visible = false;
            this.ponly.Click += new System.EventHandler(this.ponly_Click);
            // 
            // pandu
            // 
            this.pandu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.pandu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pandu.ForeColor = System.Drawing.Color.Black;
            this.pandu.Location = new System.Drawing.Point(163, 316);
            this.pandu.Name = "pandu";
            this.pandu.Size = new System.Drawing.Size(198, 42);
            this.pandu.TabIndex = 18;
            this.pandu.Text = "Public and Unlisted";
            this.pandu.UseVisualStyleBackColor = false;
            this.pandu.Visible = false;
            this.pandu.Click += new System.EventHandler(this.pandu_Click);
            // 
            // sortPanel
            // 
            this.sortPanel.Controls.Add(this.paranthesiscbx);
            this.sortPanel.Controls.Add(this.incDate);
            this.sortPanel.Controls.Add(this.rbName);
            this.sortPanel.Controls.Add(this.rbUD);
            this.sortPanel.Location = new System.Drawing.Point(12, 315);
            this.sortPanel.Name = "sortPanel";
            this.sortPanel.Size = new System.Drawing.Size(145, 90);
            this.sortPanel.TabIndex = 20;
            // 
            // paranthesiscbx
            // 
            this.paranthesiscbx.AutoSize = true;
            this.paranthesiscbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.paranthesiscbx.Location = new System.Drawing.Point(3, 66);
            this.paranthesiscbx.Name = "paranthesiscbx";
            this.paranthesiscbx.Size = new System.Drawing.Size(118, 17);
            this.paranthesiscbx.TabIndex = 18;
            this.paranthesiscbx.Text = "Include paranthesis";
            this.paranthesiscbx.UseVisualStyleBackColor = true;
            this.paranthesiscbx.Visible = false;
            // 
            // incDate
            // 
            this.incDate.AutoSize = true;
            this.incDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.incDate.Location = new System.Drawing.Point(3, 46);
            this.incDate.Name = "incDate";
            this.incDate.Size = new System.Drawing.Size(133, 17);
            this.incDate.TabIndex = 17;
            this.incDate.Text = "Include the date in title";
            this.incDate.UseVisualStyleBackColor = true;
            this.incDate.CheckedChanged += new System.EventHandler(this.incDate_CheckedChanged);
            // 
            // screenshotPanel
            // 
            this.screenshotPanel.Controls.Add(this.includeGameFolders);
            this.screenshotPanel.Controls.Add(this.incscreenshots);
            this.screenshotPanel.Controls.Add(this.dntscreenshots);
            this.screenshotPanel.Location = new System.Drawing.Point(366, 315);
            this.screenshotPanel.Name = "screenshotPanel";
            this.screenshotPanel.Size = new System.Drawing.Size(158, 90);
            this.screenshotPanel.TabIndex = 21;
            // 
            // includeGameFolders
            // 
            this.includeGameFolders.AutoSize = true;
            this.includeGameFolders.Checked = true;
            this.includeGameFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeGameFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.includeGameFolders.Location = new System.Drawing.Point(3, 46);
            this.includeGameFolders.Name = "includeGameFolders";
            this.includeGameFolders.Size = new System.Drawing.Size(120, 17);
            this.includeGameFolders.TabIndex = 18;
            this.includeGameFolders.Text = "Create game folders";
            this.includeGameFolders.UseVisualStyleBackColor = true;
            // 
            // incscreenshots
            // 
            this.incscreenshots.AutoSize = true;
            this.incscreenshots.Checked = true;
            this.incscreenshots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.incscreenshots.Location = new System.Drawing.Point(3, 0);
            this.incscreenshots.Name = "incscreenshots";
            this.incscreenshots.Size = new System.Drawing.Size(120, 17);
            this.incscreenshots.TabIndex = 15;
            this.incscreenshots.TabStop = true;
            this.incscreenshots.Text = "Include screenshots";
            this.incscreenshots.UseVisualStyleBackColor = true;
            // 
            // dntscreenshots
            // 
            this.dntscreenshots.AutoSize = true;
            this.dntscreenshots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(178)))), ((int)(((byte)(179)))));
            this.dntscreenshots.Location = new System.Drawing.Point(3, 23);
            this.dntscreenshots.Name = "dntscreenshots";
            this.dntscreenshots.Size = new System.Drawing.Size(147, 17);
            this.dntscreenshots.TabIndex = 16;
            this.dntscreenshots.Text = "Don\'t include screenshots";
            this.dntscreenshots.UseVisualStyleBackColor = true;
            // 
            // logo
            // 
            this.logo.Cursor = System.Windows.Forms.Cursors.Default;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(3, 4);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(132, 36);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 22;
            this.logo.TabStop = false;
            // 
            // paypal
            // 
            this.paypal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paypal.Image = ((System.Drawing.Image)(resources.GetObject("paypal.Image")));
            this.paypal.Location = new System.Drawing.Point(164, 303);
            this.paypal.Name = "paypal";
            this.paypal.Size = new System.Drawing.Size(197, 102);
            this.paypal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.paypal.TabIndex = 23;
            this.paypal.TabStop = false;
            this.paypal.Visible = false;
            this.paypal.Click += new System.EventHandler(this.paypal_Click);
            // 
            // infolbl
            // 
            this.infolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infolbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.infolbl.Location = new System.Drawing.Point(12, 268);
            this.infolbl.Name = "infolbl";
            this.infolbl.Size = new System.Drawing.Size(501, 29);
            this.infolbl.TabIndex = 24;
            this.infolbl.Text = "Please consider donating if you support this project";
            this.infolbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infolbl.Visible = false;
            // 
            // Infotimer
            // 
            this.Infotimer.Interval = 10000;
            this.Infotimer.Tick += new System.EventHandler(this.Infotimer_Tick);
            // 
            // didyouknow
            // 
            this.didyouknow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.didyouknow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(179)))), ((int)(((byte)(178)))));
            this.didyouknow.Location = new System.Drawing.Point(12, 296);
            this.didyouknow.Name = "didyouknow";
            this.didyouknow.Size = new System.Drawing.Size(501, 102);
            this.didyouknow.TabIndex = 25;
            this.didyouknow.Text = "Please consider donating if you support this project";
            this.didyouknow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.didyouknow.Visible = false;
            this.didyouknow.Click += new System.EventHandler(this.Didyouknow_Click);
            // 
            // connected
            // 
            this.connected.Enabled = true;
            this.connected.Interval = 1000;
            this.connected.Tick += new System.EventHandler(this.connected_Tick);
            // 
            // Refresher
            // 
            this.Refresher.Interval = 10000;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // Plays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(525, 418);
            this.Controls.Add(this.didyouknow);
            this.Controls.Add(this.downloadingrn);
            this.Controls.Add(this.infolbl);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.screenshotPanel);
            this.Controls.Add(this.sortPanel);
            this.Controls.Add(this.ponly);
            this.Controls.Add(this.loadingind);
            this.Controls.Add(this.folderpicker);
            this.Controls.Add(this.minimizebtn);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.step4);
            this.Controls.Add(this.step3);
            this.Controls.Add(this.step2);
            this.Controls.Add(this.step1);
            this.Controls.Add(this.st);
            this.Controls.Add(this.usernametb);
            this.Controls.Add(this.pandu);
            this.Controls.Add(this.Downloadbtn);
            this.Controls.Add(this.paypal);
            this.Controls.Add(this.usernamelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plays";
            this.Text = "Plays";
            this.Load += new System.EventHandler(this.Plays_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Plays_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Plays_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderpicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingind)).EndInit();
            this.sortPanel.ResumeLayout(false);
            this.sortPanel.PerformLayout();
            this.screenshotPanel.ResumeLayout(false);
            this.screenshotPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paypal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Downloadbtn;
        private System.Windows.Forms.Timer loginTimer;
        private System.Windows.Forms.Label st;
        private System.Windows.Forms.Label step1;
        private System.Windows.Forms.Label step2;
        private System.Windows.Forms.Label step3;
        private System.Windows.Forms.Label step4;
        private System.Windows.Forms.TextBox usernametb;
        private System.Windows.Forms.TextBox passwordtb;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Timer donetimer;
        private System.Windows.Forms.Label downloadingrn;
        private System.Windows.Forms.PictureBox closebtn;
        private System.Windows.Forms.PictureBox minimizebtn;
        private System.Windows.Forms.PictureBox folderpicker;
        private System.Windows.Forms.FolderBrowserDialog folderdialog;
        private System.Windows.Forms.PictureBox loadingind;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbUD;
        private System.Windows.Forms.Button ponly;
        private System.Windows.Forms.Button pandu;
        private System.Windows.Forms.Panel sortPanel;
        private System.Windows.Forms.Panel screenshotPanel;
        private System.Windows.Forms.RadioButton incscreenshots;
        private System.Windows.Forms.RadioButton dntscreenshots;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox paypal;
        private System.Windows.Forms.Label infolbl;
        private System.Windows.Forms.Timer Infotimer;
        private System.Windows.Forms.Label didyouknow;
        private System.Windows.Forms.CheckBox incDate;
        private System.Windows.Forms.CheckBox paranthesiscbx;
        private System.Windows.Forms.CheckBox includeGameFolders;
        private System.Windows.Forms.Timer connected;
        private System.Windows.Forms.Timer Refresher;
    }
}

