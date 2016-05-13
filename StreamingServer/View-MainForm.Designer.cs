namespace StreamingServer
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
            this.listenLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.rtpHeaderCheck = new System.Windows.Forms.CheckBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.frameLabel = new System.Windows.Forms.Label();
            this.frameTextBox = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.clientRequestLabel = new System.Windows.Forms.Label();
            this.serverStatusInfo = new System.Windows.Forms.TextBox();
            this.clientRequestInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listenLabel
            // 
            this.listenLabel.AutoSize = true;
            this.listenLabel.Location = new System.Drawing.Point(13, 13);
            this.listenLabel.Name = "listenLabel";
            this.listenLabel.Size = new System.Drawing.Size(100, 17);
            this.listenLabel.TabIndex = 0;
            this.listenLabel.Text = "Listen on Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(121, 13);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 22);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "3000";
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(228, 13);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(75, 23);
            this.listenButton.TabIndex = 2;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            // 
            // rtpHeaderCheck
            // 
            this.rtpHeaderCheck.AutoSize = true;
            this.rtpHeaderCheck.Location = new System.Drawing.Point(479, 15);
            this.rtpHeaderCheck.Name = "rtpHeaderCheck";
            this.rtpHeaderCheck.Size = new System.Drawing.Size(142, 21);
            this.rtpHeaderCheck.TabIndex = 3;
            this.rtpHeaderCheck.Text = "Print RTP Header";
            this.rtpHeaderCheck.UseVisualStyleBackColor = true;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(13, 55);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(125, 17);
            this.ipLabel.TabIndex = 4;
            this.ipLabel.Text = "Server IP address:";
            // 
            // frameLabel
            // 
            this.frameLabel.AutoSize = true;
            this.frameLabel.Location = new System.Drawing.Point(433, 55);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(64, 17);
            this.frameLabel.TabIndex = 6;
            this.frameLabel.Text = "Frame #:";
            // 
            // frameTextBox
            // 
            this.frameTextBox.Location = new System.Drawing.Point(503, 55);
            this.frameTextBox.Name = "frameTextBox";
            this.frameTextBox.ReadOnly = true;
            this.frameTextBox.Size = new System.Drawing.Size(118, 22);
            this.frameTextBox.TabIndex = 7;
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(148, 55);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.ReadOnly = true;
            this.ipTextBox.Size = new System.Drawing.Size(100, 22);
            this.ipTextBox.TabIndex = 8;
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Location = new System.Drawing.Point(13, 94);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(94, 17);
            this.serverStatusLabel.TabIndex = 9;
            this.serverStatusLabel.Text = "Server Status";
            // 
            // clientRequestLabel
            // 
            this.clientRequestLabel.AutoSize = true;
            this.clientRequestLabel.Location = new System.Drawing.Point(13, 283);
            this.clientRequestLabel.Name = "clientRequestLabel";
            this.clientRequestLabel.Size = new System.Drawing.Size(107, 17);
            this.clientRequestLabel.TabIndex = 11;
            this.clientRequestLabel.Text = "Client Requests";
            // 
            // serverStatusInfo
            // 
            this.serverStatusInfo.Location = new System.Drawing.Point(22, 115);
            this.serverStatusInfo.Multiline = true;
            this.serverStatusInfo.Name = "serverStatusInfo";
            this.serverStatusInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverStatusInfo.Size = new System.Drawing.Size(599, 165);
            this.serverStatusInfo.TabIndex = 13;
            // 
            // clientRequestInfo
            // 
            this.clientRequestInfo.Location = new System.Drawing.Point(22, 303);
            this.clientRequestInfo.Multiline = true;
            this.clientRequestInfo.Name = "clientRequestInfo";
            this.clientRequestInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientRequestInfo.Size = new System.Drawing.Size(599, 165);
            this.clientRequestInfo.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 488);
            this.Controls.Add(this.clientRequestInfo);
            this.Controls.Add(this.serverStatusInfo);
            this.Controls.Add(this.clientRequestLabel);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.frameTextBox);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.rtpHeaderCheck);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.listenLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listenLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.CheckBox rtpHeaderCheck;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.TextBox frameTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.Label clientRequestLabel;
        private System.Windows.Forms.TextBox serverStatusInfo;
        private System.Windows.Forms.TextBox clientRequestInfo;
    }
}

