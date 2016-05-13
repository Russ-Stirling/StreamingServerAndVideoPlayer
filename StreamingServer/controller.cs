using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using System.Windows.Forms;

namespace StreamingServer
{
    class controller
    {
        private static Form1 _view;
        private bool check = false;

        public void listenButton_Click(object sender, EventArgs e)
        {
            //Method to implement the behaviour: Listenbtnclick(new thread is created)
            _view = (Form1)((Button)sender).FindForm(); //get the view 
            _view.disableListenBut(); //disable the listen button (function in view)

            Thread connectionsThread = new Thread(listeningThread);
            connectionsThread.IsBackground = true;
            connectionsThread.Start(); //create a new thread to listen for connections 

        }

        public void listeningThread()
        {
            Model_RTSP RTSPObject = new Model_RTSP(int.Parse(_view.getPortTextBox())); //create a RTSP model with the port in the port text box
            _view.SetIpInfoBox(RTSPObject.getIP().ToString()); //set the ip box
            
            while (true)
            {
                _view.SetServerInfoBox("Waiting for new connection." + "\r\n"); //display server info
                //listen for connections here

                Socket sock = RTSPObject.acceptConnection(); //make a connection to a client
                
                _view.SetServerInfoBox("The client "+sock.RemoteEndPoint.ToString()+ " has connected.\r\n"); //inform server there is connection
                //create new communication thread
                Thread communicationsThread = new Thread(new ParameterizedThreadStart(communicationThread));
                communicationsThread.IsBackground = true;
                communicationsThread.Start(sock); //create a thread for communication on that connection
            }
        }
        public void communicationThread(object x)
        {
            communicationThread((Socket)x); //cast object as socket and call function for socket communication
        }
        public void communicationThread(Socket sock)
        {
            String str, res; 
            char[] delims = { ' ', '/', '\n', ':' }; //how the string request will be split up
            String[] req;
            Model_Client Client = new Model_Client(sock); //pass the socket to the client constructor 
            Model_RTP rtp = new Model_RTP(); //make an rtp model
            
            Random v = new Random();
            int sess = v.Next(); //create random session number
            System.Timers.Timer time = new System.Timers.Timer(100); //create a timer and set interval to 100ms
            time.AutoReset = true;
            int frame = 0;
            time.Elapsed += (sender, e) => OnTimedEvent(sender, e, rtp, frame, _view, getCheck()); //reference function to be called on timer elapsed event
            _view.SetFrameInfoBox("0");
            while (Client.connected()) //as long as the client connection is active
            {
                req = null;
                str = Client.rec(); //receive the command
                _view.SetClientInfoBox("\r\n" + str); //print the command
                req = str.Split(delims); //split up the command
                if (req[0].Equals("SETUP"))
                {
                    time.Stop(); //if timer is running (say video ended on its own rather than by hitting teardown) stop the timer
                    rtp.setInfo(Int32.Parse(req[17]), req[4], req[6]); //set the information for the rtp model (port, ip, path)
                    Console.WriteLine("In setup");
                    Console.WriteLine(req[6]);
                    res = "RTSP/1.0 200 OK\r\nCSeq: " + req[11] + "\nSession: " + sess; //create response
                    Client.send(res); //send response
                }
                else if (req[0].Equals("PLAY"))
                {
                    Console.WriteLine("In Play");
                    Console.WriteLine(sess);
                    res = "RTSP/1.0 200 OK\r\nCSeq: " + req[11] + "\nSession: " + sess; //create response
                    Client.send(res); //send response

                    time.Enabled = true; //start the timer

                }
                else if (req[0].Equals("PAUSE"))
                {
                    Console.WriteLine("In setup");
                    res = "RTSP/1.0 200 OK\r\nCSeq: " + req[11] + "\nSession: " + sess; //create response
                    time.Stop(); //stop the timer
                    Client.send(res); //send response


                }
                else if (req[0].Equals("TEARDOWN"))
                {
                    Console.WriteLine("In setup");
                    res = "RTSP/1.0 200 OK\r\nCSeq: " + req[11] + "\nSession: " + sess; //create response
                    Client.send(res); //send response
                    time.Stop(); //stop timer
                    rtp.teardown(); //close udp connection 
                }
                else
                {
                    //Console.WriteLine("This request does not exist.");
                }
                str = null; //clear string
            }
            time.Stop(); //stop the timer when connection is lost
            _view.SetFrameInfoBox(""); //clear the frame box
        }
        public bool getCheck()
        {
            return check; //pass whether the the check box has been checked
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, Model_RTP rtp, int frame, Form1 form, bool check)
        {
            rtp.send(rtp.getFrame()); //make the packet and send it in rtp
            form.SetFrameInfoBox(rtp.getFrameNum()); //get the current frame from rtp and put it in the frame info box
            if (check) //if the checkbox is checked
            {
                form.SetServerInfoBox(rtp.getHead()); //print the packet header to server info
            }
        }

        public void rtpHeaderCheck_CheckedChanged(object sender, EventArgs e) //flip the boolean of check
        {
            if (getCheck())
            {
                check = false;
            }
            else
            {
                check = true;
            }
        }
    }
}
