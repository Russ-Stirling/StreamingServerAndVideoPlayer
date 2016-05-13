using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace VideoPlayer
{
    class Model_RTSP
    {
        private int port;
        IPAddress ip;
        Socket serverConnection;
        IPEndPoint serverEP;
        String clientIP;
        int rc;
        byte[] rb;
        bool testCon=true;

        public Model_RTSP(int _port, String _ip)
        {
            port = _port; //set the port 
            ip = IPAddress.Parse(_ip); //set ip
            serverEP = new IPEndPoint(ip, port); // create endpoint based on port
            serverConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create tcp socket
            try
            {
                serverConnection.Connect(serverEP); //make tcp connection
                clientIP = ((IPEndPoint)this.serverConnection.LocalEndPoint).Address.ToString(); //store the client ip address
                //testCon = true;
            }
            catch
            {
                // Connect failed so try the next one
                // Make sure to close the socket we opened
                testCon = false;
                if (serverConnection != null)
                {
                    serverConnection.Close(); //close the tcp connection
                }
            }
        }
        public bool getTest()
        {
            return testCon; //return test in initial connect attempt
        }
        public void sendMessage(String mess)
        {
            rb = System.Text.Encoding.ASCII.GetBytes(mess); //encode a string as byte array
            serverConnection.Send(rb); //send it over the connection
            //String res = receiveMessage();
        }
        public String receiveMessage()
        {
            rb = new byte[1024];
            rc = serverConnection.Receive(rb); //receive a byte arry
            return System.Text.Encoding.ASCII.GetString(rb); //return it as a string
        }
        public bool connected() //check to see if socket is still connected. done in this way so even ungraceful disconnection will be seen
        {
            bool part1 = serverConnection.Poll(1000, SelectMode.SelectRead);
            bool part2 = (serverConnection.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
        public void teardown()
        {
            serverConnection.Close(); //close tcp socket
        }
        public String getClientIP()
        {
            return clientIP; //return the client ip
        }

    }
}
