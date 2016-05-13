using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace StreamingServer
{
    class Model_RTSP
    {
        private int port;
        IPAddress ip = IPAddress.Parse("127.0.0.1"); //only operating on local host, otherwise would pass this as string in constructor
        Socket clientConnection;
        IPEndPoint groupEP;
        Socket listener;

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Model_RTSP(int _port)
        {
            port = _port; //set the port 
            groupEP = new IPEndPoint(ip, port); // create endpoint based on port
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create tcp socket
            try
            {
                listener.Bind(groupEP); //bind and listen on tcp socket
                listener.Listen(100);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public IPAddress getIP() //well... gets the ip
        {
            return ip;
        }
        public Socket acceptConnection()
        {         
            try
            {
                clientConnection = listener.Accept(); //creates a new tcp socket for communication between client and server
                Console.Write("success accepting client connection");
            }
            catch (SocketException err)
            {
                Console.Write("error occured accepting client connection");
            }
            return clientConnection; //return the new socket
        }
    }
}
