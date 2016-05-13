namespace VideoPlayer
{
    partial class Form1
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
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.videoNameLabel = new System.Windows.Forms.Label();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.serverResponseTextBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.GroupBox();
            this.teardownPlayer = new System.Windows.Forms.PictureBox();
            this.pausePlayer = new System.Windows.Forms.PictureBox();
            this.playPlayer = new System.Windows.Forms.PictureBox();
            this.setupPlayer = new System.Windows.Forms.PictureBox();
            this.videoPlayer = new System.Windows.Forms.PictureBox();
            this.pauseBut = new System.Windows.Forms.Button();
            this.playBut = new System.Windows.Forms.Button();
            this.teardownBut = new System.Windows.Forms.Button();
            this.setupBut = new System.Windows.Forms.Button();
            this.connectBut = new System.Windows.Forms.Button();
            this.exitBut = new System.Windows.Forms.Button();
            this.packetCheck = new System.Windows.Forms.CheckBox();
            this.headerCheck = new System.Windows.Forms.CheckBox();
            this.videoNameDrop = new System.Windows.Forms.ComboBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teardownPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(13, 13);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(110, 17);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Connect to Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(130, 13);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 22);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "3000";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(269, 13);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(126, 17);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "Server IP Address:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(402, 13);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(100, 22);
            this.ipTextBox.TabIndex = 3;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // videoNameLabel
            // 
            this.videoNameLabel.AutoSize = true;
            this.videoNameLabel.Location = new System.Drawing.Point(525, 14);
            this.videoNameLabel.Name = "videoNameLabel";
            this.videoNameLabel.Size = new System.Drawing.Size(85, 17);
            this.videoNameLabel.TabIndex = 4;
            this.videoNameLabel.Text = "Video Name";
            // 
            // reportTextBox
            // 
            this.reportTextBox.Location = new System.Drawing.Point(16, 434);
            this.reportTextBox.MinimumSize = new System.Drawing.Size(165, 165);
            this.reportTextBox.Multiline = true;
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportTextBox.Size = new System.Drawing.Size(615, 165);
            this.reportTextBox.TabIndex = 7;
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(13, 602);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(129, 17);
            this.responseLabel.TabIndex = 8;
            this.responseLabel.Text = "Server Responses:";
            // 
            // serverResponseTextBox
            // 
            this.serverResponseTextBox.Location = new System.Drawing.Point(16, 622);
            this.serverResponseTextBox.MinimumSize = new System.Drawing.Size(4, 165);
            this.serverResponseTextBox.Multiline = true;
            this.serverResponseTextBox.Name = "serverResponseTextBox";
            this.serverResponseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverResponseTextBox.Size = new System.Drawing.Size(644, 165);
            this.serverResponseTextBox.TabIndex = 9;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.teardownPlayer);
            this.panel.Controls.Add(this.pausePlayer);
            this.panel.Controls.Add(this.playPlayer);
            this.panel.Controls.Add(this.setupPlayer);
            this.panel.Controls.Add(this.videoPlayer);
            this.panel.Controls.Add(this.pauseBut);
            this.panel.Controls.Add(this.playBut);
            this.panel.Controls.Add(this.teardownBut);
            this.panel.Controls.Add(this.setupBut);
            this.panel.Location = new System.Drawing.Point(16, 41);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(722, 387);
            this.panel.TabIndex = 10;
            this.panel.TabStop = false;
            // 
            // teardownPlayer
            // 
            this.teardownPlayer.Enabled = false;
            this.teardownPlayer.Image = global::VideoPlayer.Properties.Resources.Teardown;
            this.teardownPlayer.Location = new System.Drawing.Point(424, 286);
            this.teardownPlayer.Name = "teardownPlayer";
            this.teardownPlayer.Size = new System.Drawing.Size(50, 50);
            this.teardownPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.teardownPlayer.TabIndex = 3;
            this.teardownPlayer.TabStop = false;
            this.teardownPlayer.Visible = false;
            // 
            // pausePlayer
            // 
            this.pausePlayer.Enabled = false;
            this.pausePlayer.Image = global::VideoPlayer.Properties.Resources.Pause;
            this.pausePlayer.Location = new System.Drawing.Point(368, 286);
            this.pausePlayer.Name = "pausePlayer";
            this.pausePlayer.Size = new System.Drawing.Size(50, 50);
            this.pausePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pausePlayer.TabIndex = 2;
            this.pausePlayer.TabStop = false;
            this.pausePlayer.Visible = false;
            // 
            // playPlayer
            // 
            this.playPlayer.Enabled = false;
            this.playPlayer.Image = global::VideoPlayer.Properties.Resources.Play;
            this.playPlayer.Location = new System.Drawing.Point(312, 286);
            this.playPlayer.Name = "playPlayer";
            this.playPlayer.Size = new System.Drawing.Size(50, 50);
            this.playPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playPlayer.TabIndex = 1;
            this.playPlayer.TabStop = false;
            this.playPlayer.Visible = false;
            // 
            // setupPlayer
            // 
            this.setupPlayer.Enabled = false;
            this.setupPlayer.Image = global::VideoPlayer.Properties.Resources.Setup;
            this.setupPlayer.Location = new System.Drawing.Point(256, 286);
            this.setupPlayer.Name = "setupPlayer";
            this.setupPlayer.Size = new System.Drawing.Size(50, 50);
            this.setupPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.setupPlayer.TabIndex = 0;
            this.setupPlayer.TabStop = false;
            this.setupPlayer.Visible = false;
            // 
            // videoPlayer
            // 
            this.videoPlayer.Location = new System.Drawing.Point(7, 22);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(709, 314);
            this.videoPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoPlayer.TabIndex = 4;
            this.videoPlayer.TabStop = false;
            this.videoPlayer.MouseEnter += new System.EventHandler(this.videoPlayer_MouseEnter);
            this.videoPlayer.MouseLeave += new System.EventHandler(this.videoPlayer_MouseLeave);
            // 
            // pauseBut
            // 
            this.pauseBut.Enabled = false;
            this.pauseBut.Location = new System.Drawing.Point(386, 342);
            this.pauseBut.Name = "pauseBut";
            this.pauseBut.Size = new System.Drawing.Size(150, 39);
            this.pauseBut.TabIndex = 3;
            this.pauseBut.Text = "Pause";
            this.pauseBut.UseVisualStyleBackColor = true;
            // 
            // playBut
            // 
            this.playBut.Enabled = false;
            this.playBut.Location = new System.Drawing.Point(196, 342);
            this.playBut.Name = "playBut";
            this.playBut.Size = new System.Drawing.Size(150, 39);
            this.playBut.TabIndex = 2;
            this.playBut.Text = "Play";
            this.playBut.UseVisualStyleBackColor = true;
            // 
            // teardownBut
            // 
            this.teardownBut.Enabled = false;
            this.teardownBut.Location = new System.Drawing.Point(566, 342);
            this.teardownBut.Name = "teardownBut";
            this.teardownBut.Size = new System.Drawing.Size(150, 39);
            this.teardownBut.TabIndex = 1;
            this.teardownBut.Text = "Teardown";
            this.teardownBut.UseVisualStyleBackColor = true;
            // 
            // setupBut
            // 
            this.setupBut.Enabled = false;
            this.setupBut.Location = new System.Drawing.Point(6, 342);
            this.setupBut.Name = "setupBut";
            this.setupBut.Size = new System.Drawing.Size(150, 39);
            this.setupBut.TabIndex = 0;
            this.setupBut.Text = "Setup";
            this.setupBut.UseVisualStyleBackColor = true;
            // 
            // connectBut
            // 
            this.connectBut.Location = new System.Drawing.Point(666, 735);
            this.connectBut.Name = "connectBut";
            this.connectBut.Size = new System.Drawing.Size(75, 23);
            this.connectBut.TabIndex = 11;
            this.connectBut.Text = "Connect";
            this.connectBut.UseVisualStyleBackColor = true;
            // 
            // exitBut
            // 
            this.exitBut.Enabled = false;
            this.exitBut.Location = new System.Drawing.Point(666, 764);
            this.exitBut.Name = "exitBut";
            this.exitBut.Size = new System.Drawing.Size(75, 23);
            this.exitBut.TabIndex = 12;
            this.exitBut.Text = "Exit";
            this.exitBut.UseVisualStyleBackColor = true;
            // 
            // packetCheck
            // 
            this.packetCheck.AutoSize = true;
            this.packetCheck.Location = new System.Drawing.Point(643, 434);
            this.packetCheck.Name = "packetCheck";
            this.packetCheck.Size = new System.Drawing.Size(120, 21);
            this.packetCheck.TabIndex = 13;
            this.packetCheck.Text = "Packet Report";
            this.packetCheck.UseVisualStyleBackColor = true;
            // 
            // headerCheck
            // 
            this.headerCheck.AutoSize = true;
            this.headerCheck.Location = new System.Drawing.Point(643, 461);
            this.headerCheck.Name = "headerCheck";
            this.headerCheck.Size = new System.Drawing.Size(110, 21);
            this.headerCheck.TabIndex = 14;
            this.headerCheck.Text = "Print Header";
            this.headerCheck.UseVisualStyleBackColor = true;
            // 
            // videoNameDrop
            // 
            this.videoNameDrop.FormattingEnabled = true;
            this.videoNameDrop.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.videoNameDrop.Location = new System.Drawing.Point(617, 10);
            this.videoNameDrop.Name = "videoNameDrop";
            this.videoNameDrop.Size = new System.Drawing.Size(121, 24);
            this.videoNameDrop.TabIndex = 15;
            this.videoNameDrop.Text = "video1.mjpeg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 851);
            this.Controls.Add(this.videoNameDrop);
            this.Controls.Add(this.headerCheck);
            this.Controls.Add(this.packetCheck);
            this.Controls.Add(this.exitBut);
            this.Controls.Add(this.connectBut);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.serverResponseTextBox);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.reportTextBox);
            this.Controls.Add(this.videoNameLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teardownPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label videoNameLabel;
        private System.Windows.Forms.TextBox reportTextBox;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.TextBox serverResponseTextBox;
        private System.Windows.Forms.GroupBox panel;
        private System.Windows.Forms.PictureBox teardownPlayer;
        private System.Windows.Forms.PictureBox pausePlayer;
        private System.Windows.Forms.PictureBox playPlayer;
        private System.Windows.Forms.PictureBox setupPlayer;
        private System.Windows.Forms.PictureBox videoPlayer;
        private System.Windows.Forms.Button pauseBut;
        private System.Windows.Forms.Button playBut;
        private System.Windows.Forms.Button teardownBut;
        private System.Windows.Forms.Button setupBut;
        private System.Windows.Forms.Button connectBut;
        private System.Windows.Forms.Button exitBut;
        private System.Windows.Forms.CheckBox packetCheck;
        private System.Windows.Forms.CheckBox headerCheck;
        private System.Windows.Forms.ComboBox videoNameDrop;
    }
}

