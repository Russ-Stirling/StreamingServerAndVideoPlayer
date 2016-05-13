using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        bool plC = false;
        bool paC = false;
        bool seC = false;
        bool teC = false;

        public Form1()
        {
            controller _controller = new controller(); //create a controller
            InitializeComponent();
            //link the buttons to functions in controller
            this.connectBut.Click += new System.EventHandler(_controller.connectBut_Click);
            this.setupBut.Click += new System.EventHandler(_controller.setupBut_Click);
            this.playBut.Click += new System.EventHandler(_controller.playBut_Click);
            this.pauseBut.Click += new System.EventHandler(_controller.pauseBut_Click);
            this.teardownBut.Click += new System.EventHandler(_controller.teardownBut_Click);
            this.exitBut.Click += new System.EventHandler(_controller.exitBut_Click);

            //link the checkboxes to function in controller
            this.packetCheck.CheckedChanged += new System.EventHandler(_controller.packetCheck_CheckedChanged);
            this.headerCheck.CheckedChanged += new System.EventHandler(_controller.headerCheck_CheckedChanged);

            //link the in video controls (will do last)
            this.setupPlayer.Click += new System.EventHandler(_controller.setupBut_Click);
            this.playPlayer.Click += new System.EventHandler(_controller.playBut_Click);
            this.pausePlayer.Click += new System.EventHandler(_controller.pauseBut_Click);
            this.teardownPlayer.Click += new System.EventHandler(_controller.teardownBut_Click);
        }

        public void disableConnect(bool e) // disable connect button
        {
            this.connectBut.Enabled = e;
        }
        delegate void SetInfoCallback(string info); //delagate fot info setting

        public void SetIpInfoBox(String _msg) //set info for modify ip box
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_text);
            this.Invoke(d, new object[] { text });
        }

        public void add_text(String _msg) //modify ip text box
        {
            this.ipTextBox.Text = _msg;
        }

        public void SetServerResponseBox(String _msg) //setting the server response info
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_server_text);
            this.Invoke(d, new object[] { text });
        }

        public void add_server_text(String _msg) //setting the server status text boxes to info
        {
            this.serverResponseTextBox.Text += _msg;
        }

        public void SetClientInfoBox(String _msg) //setting the client status info
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_Request_text);
            this.Invoke(d, new object[] { text });
        }

        public void add_Request_text(String _msg) //setting the client status text boxes to info
        {
            this.reportTextBox.Text += _msg;
        }
        public String getPortTextBox() //get string in port text box
        {
            return portTextBox.Text;
        }
        public String getIPTextBox() //get string in port text box
        {
            return ipTextBox.Text;
        }
        public String getVideoName() //get string in port text box
        {
            return videoNameDrop.Text;
        }
        public void playEnabled(bool e) //enable/disable play controls
        {
            playBut.Enabled = e;
            playPlayer.Enabled = e;
            plC = e;
        }
        public void pauseEnabled(bool e) //enable/disable pause controls
        {
            pauseBut.Enabled = e;
            pausePlayer.Enabled = e;
            paC = e;
        }
        public void setupEnabled(bool e) //enable/disable setup controls
        {
            setupBut.Enabled = e;
            setupPlayer.Enabled = e;
            seC = e;
        }
        public void teardownEnabled(bool e) //enable/disable teardown controls
        {
            teardownBut.Enabled = e;
            teardownPlayer.Enabled = e;
            teC = e;
        }
        public void exitEnabled(bool e) //enable/disable exit controls
        {
            exitBut.Enabled = e;
        }

        private void videoPlayer_MouseEnter(object sender, EventArgs e) //when mouse enters the video player area enable the necesary video controls
        {
            //videoControls.Visible = true;
            if (plC)
            {
                playPlayer.Visible = true;
            }
            if (seC)
            {
                setupPlayer.Visible = true;
            }
            if (paC)
            {
                pausePlayer.Visible = true;
            }
            if(teC){
            teardownPlayer.Visible = true;}
        }

        private void videoPlayer_MouseLeave(object sender, EventArgs e) //when mouse leaves the video player make all video player controls invisible
        {
            if (panel.GetChildAtPoint(panel.PointToClient(MousePosition)) == null)
            {
                playPlayer.Visible = false;
                setupPlayer.Visible = false;
                pausePlayer.Visible = false;
                teardownPlayer.Visible = false;
            }
        }
        public void nextFrame(Image frame) //set the video frame
        {
            videoPlayer.Image = frame;
        }
    }
}
