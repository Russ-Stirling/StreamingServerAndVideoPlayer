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
    class Model_RTP
    {
        
        private Socket videoConnection;
        int port;
        IPAddress ip;
        IPEndPoint ep;
        EndPoint serverEp;
        int rc;
        Byte[] rb;
        bool connected = true;
        public Model_RTP(String _ip, int _port )
        {
            videoConnection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //make the udp socket
            port = _port;
            ip = IPAddress.Parse(_ip); ;
            ep = new IPEndPoint(ip, port);
            videoConnection.Bind(ep); //bind the udp socket
            connected = true;
        }
        public void setEP(EndPoint _serverEp)
        {
            serverEp = _serverEp; //set the endpoint
        }
        public byte[] rec() //receive data over udp socket
        {
            rb = new byte[200000]; //byte array large enough to revceive data
            videoConnection.ReceiveTimeout = 1000; //set the timeout
            try
            {
                rc = videoConnection.ReceiveFrom(rb, ref serverEp);
                //Console.WriteLine("i read once");
            }
            catch(SocketException)
            {
                connected = false; //data has stopped sending
                Console.WriteLine("i didnt a udp packet.");
            }
            return rb;
        }
        public bool getConnected()
        {
            return connected; //return a boolean
        }

    }
}
