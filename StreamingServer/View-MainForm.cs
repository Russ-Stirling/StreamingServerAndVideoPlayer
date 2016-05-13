using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace StreamingServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            controller _controller = new controller(); //create a controller
            InitializeComponent();
            //link the listen button to function in controller
            this.listenButton.Click += new System.EventHandler(_controller.listenButton_Click);
            //link the check box to function in controller
            this.rtpHeaderCheck.CheckedChanged += new System.EventHandler(_controller.rtpHeaderCheck_CheckedChanged);

        }
        delegate void SetInfoCallback(string info); //delagate fot info setting

        public void SetFrameInfoBox(String _msg) //set text for changing frame
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_frame);
            this.Invoke(d, new object[] { text });
        }

        public void add_frame(String _msg) //actually modify frame info
        {
            this.frameTextBox.Text = _msg;
        }
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


        public void SetServerInfoBox(String _msg) //setting the server status info
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_Msg_text);
            this.Invoke(d, new object[] { text });
        }

        public void add_Msg_text(String _msg) //setting the server status text boxes to info
        {
            this.serverStatusInfo.Text += _msg;
        }

        public void SetClientInfoBox(String _msg) //setting the client status info
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_Request_text);
            this.Invoke(d, new object[] { text });
        }

        public void add_Request_text(String _msg) //setting the client status text boxes to info
        {
            this.clientRequestInfo.Text += _msg;
        }
        public String getPortTextBox() //get string in port text box
        {
            return portTextBox.Text;
        }
        
        public void disableListenBut() //disable listen button
        {
            this.listenButton.Enabled = false;
        }
        
    }
}
