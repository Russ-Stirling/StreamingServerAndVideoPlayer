using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Timers;
//using System.Threading.Timer;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace VideoPlayer
{
    class controller
    {
        private static Form1 _view;
        private int cSeq = 1;
        private int rtpPort;
        private String video;
        private Model_RTSP rtsp;
        private Model_RTP rtp;
        private String session;
        private String[] res;
        char[] delims = { ' ', '/', '\n'};
        IPEndPoint serverEP;
        System.Timers.Timer time;
        bool headerInfo = false;
        bool packetInfo = false;
        //System.Threading.Timer time;
        

        public void connectBut_Click(object sender, EventArgs e) //called when connect clicked
        {
            _view = (Form1)((Button)sender).FindForm(); //get the view
            rtsp = new Model_RTSP(int.Parse(_view.getPortTextBox()), _view.getIPTextBox()); //make an rtsp model for the connection
            if (rtsp.getTest()) //if the connection was succesful
            {
                video = _view.getVideoName(); //get the video name
                time = new System.Timers.Timer(100); //create a timer and set interval to 100ms
                time.AutoReset = true;
                time.Elapsed += (s, ev) => OnTimedEvent(s, ev, rtp, _view, headerInfo, packetInfo, time); //create function for timer event
                _view.setupEnabled(true); //enable necessary buttons
                _view.exitEnabled(true);
                _view.disableConnect(false);
            }
            else
            {
                _view.SetServerResponseBox("No server connected to this ip, port combo." + "\r\n\r\n");
                _view.SetServerResponseBox("\r\n");
                //send message saying no server at that ip and port combo.
            }
        }
        public void setupBut_Click(object sender, EventArgs e)
        {
            if (rtsp.connected()) //check that tcp socket still connected
            {
                cSeq = 1; //Purposelly resetting sequence number on each setup. To make the sequence number continously increase after tearing down and reseting up just erase this line.
                Random r = new Random();
                rtpPort = r.Next(1050, 9000); //random port between 1050 and 9000
                rtsp.sendMessage(createRequest("SETUP")); //create and send send the request over the tcp socket
                String str = rtsp.receiveMessage(); //receive response
                _view.SetServerResponseBox(str + "\r\n\r\n"); //display response
                _view.SetServerResponseBox("\r\n");
                res = str.Split(delims); //parse response and check response code
                if (res[2] == "200")
                {
                    time.Stop(); //stop timer if running due to an anomoly 
                    session = res[7]; //store session number
                    rtp = new Model_RTP(rtsp.getClientIP(), rtpPort); //make the rtp model
                    IPEndPoint point = new IPEndPoint(IPAddress.Any, 0); //store the server endpoint
                    serverEP = point;
                    rtp.setEP(serverEP); //set the rtp server endpoint

                    _view.setupEnabled(false); //enable buttons and incr seq num
                    _view.playEnabled(true);
                    _view.teardownEnabled(true);

                    cSeq++;
                }
                else
                {
                    Console.WriteLine("Setup Failed."); //debuggin check
                }
            }
            else
            {
                rtsp.teardown(); //close socket and inform user
                _view.SetServerResponseBox("Server has been shutdown. Please exit the client" + "\r\n\r\n");
                _view.SetServerResponseBox("\r\n");
            }
        }
        public void playBut_Click(object sender, EventArgs e)
        {
            if (rtsp.connected()) //check that tcp connection still active
            {
                rtsp.sendMessage(createRequest("PLAY")); //create and send send the request over the tcp socket
                String str = rtsp.receiveMessage(); //receive response
                _view.SetServerResponseBox(str + "\r\n\r\n"); //display response
                _view.SetServerResponseBox("\r\n");
                res = str.Split(delims); //parse response and check response code
                if (res[2] == "200")
                {
                    time.Enabled = true; //start the timer
                    _view.pauseEnabled(true); //enable/disble buttons and incr seq num
                    _view.playEnabled(false);
                    cSeq++;
                }
                else
                {
                    Console.WriteLine("Play Failed."); //debugging check
                }
            }
            else
            {
                rtsp.teardown(); //close tcp socket and inform user
                _view.SetServerResponseBox("Server has been shutdown. Please exit the client" + "\r\n\r\n");
                _view.SetServerResponseBox("\r\n");
            }

        }
        public void pauseBut_Click(object sender, EventArgs e)
        {
            if (rtsp.connected()) //check that tcp socket still connected
            {
                rtsp.sendMessage(createRequest("PAUSE")); //create and send send the request over the tcp socket
                String str = rtsp.receiveMessage(); //receive response
                _view.SetServerResponseBox(str + "\r\n\r\n"); //display response
                _view.SetServerResponseBox("\r\n");
                res = str.Split(delims);
                if (res[2] == "200") //check for 200 code
                {
                    time.Stop(); //stop timer
                    _view.playEnabled(true); //enable/disable buttons and incr seq num
                    _view.pauseEnabled(false);
                    cSeq++;
                }
                else
                {
                    Console.WriteLine("Pause Failed."); //debugging check
                }
            }
            else
            {
                rtsp.teardown(); //close tcp socket and inform client
                _view.SetServerResponseBox("Server has been shutdown. Please exit the client" + "\r\n\r\n");
                _view.SetServerResponseBox("\r\n");
            }
            
        }
        public void teardownBut_Click(object sender, EventArgs e)
        {
            if (rtsp.connected()) //check that server didnt close tcp connection
            {
                rtsp.sendMessage(createRequest("TEARDOWN")); //create and send send the request over the tcp socket
                String str = rtsp.receiveMessage(); //get response
                _view.SetServerResponseBox(str + "\r\n\r\n"); //print response
                _view.SetServerResponseBox("\r\n");

                res = str.Split(delims); //split up response
                if (res[2] == "200") //check for 200 code
                {
                    time.Stop(); //stop the timer
                    _view.setupEnabled(true); //enable/ disable buttons
                    _view.playEnabled(false);
                    _view.pauseEnabled(false);
                    _view.teardownEnabled(false);
                    cSeq++; //incr seq number
                }
                else
                {
                    Console.WriteLine("Teardown Failed."); //debug check
                }
            }
            else
            {
                rtsp.teardown(); //close tcp socket
                _view.SetServerResponseBox("Server has been shutdown. Please exit the client" + "\r\n\r\n"); //inform user
                _view.SetServerResponseBox("\r\n");
            }
        }
        public void exitBut_Click(object sender, EventArgs e)
        {
            time.Stop(); //stop timer if its not already stopped
            if (_view != null)
            {
                rtsp.teardown();
                _view.Close(); //if view has been set close the application
            }
        }
        public String createRequest(String type) //create the server requests
        {
            String response;
            response = type + " rtsp://" + _view.getIPTextBox() + ":" + _view.getPortTextBox() + "/" + _view.getVideoName() +" RTSP/1.0"+"\r\n";
            response += "CSeq: " + cSeq.ToString()+"\r\n";
            // getting info for the request above. below infor for setup or other commands
            if(type=="SETUP")
            {
                response += "Transport: RTP/UDP; client_port= " + rtpPort.ToString() +"\r\n";
            }
            else
            {
                response += "Session: " + session + "\r\n";
            }
            //what the requests look like
            //Console.WriteLine(response);
            /*
            COMMAND rtsp://127.0.0.1:3000/VIDEONAME RTSP/1.0
            CSeq: SEQUENCENUMBER
            Transport: RTP/UDP; client_port= RANDOMPORT or Session: SESSIONNUMBER
             */
            return response;
        }
        public void packetCheck_CheckedChanged(object sender, EventArgs e)
        {
            //reverse the boolean telling controller whether the user wants packet info displayed
            if (packetInfo)
            {
                packetInfo = false;
            }
            else
            {
                packetInfo = true;
            }
            Console.WriteLine("packet");
        }
        public void headerCheck_CheckedChanged(object sender, EventArgs e)
        {
            //reverse the boolean telling controller whether the user wants header info displayed
            if (headerInfo)
            {
                headerInfo = false;
            }
            else
            {
                headerInfo = true;
            }
            Console.WriteLine("header");
        }
        private static void OnTimedEvent(object s, ElapsedEventArgs ev, Model_RTP rtp, Form1 view, bool h, bool p, System.Timers.Timer time)
        {
            if (rtp.getConnected()) //as long as the udp connection is still receiving data
            {
                byte[] data = rtp.rec(); //receive data
                //set the picturebox to the image that is read
                RTP_Packet packet = new RTP_Packet(data); //pass the data to the rtp packet class
                String info;
                if (p) //get packet info to print if requested
                {
                    info = "Got RTP packet with SeqNum " + packet.getSeq().ToString() + ", TimeStamp " + packet.getTime().ToString() + ", Type " + packet.getType().ToString() + "\r\n";
                    _view.SetClientInfoBox(info);
                }
                if (h) //get header info to print if requested
                {
                    info = packet.getHead() + "\r\n";
                    _view.SetClientInfoBox(info);
                }
                //convert the byte array to an image
                using (var ms = new System.IO.MemoryStream(packet.getFrame()))
                {
                    _view.nextFrame(Image.FromStream(ms)); //set the image in the view
                }
            }
            else
            {
                _view.pauseEnabled(false); //enable correct buttons and stop timer if the udp stops receiving data
                time.Stop();
            }
        }
    }
}
