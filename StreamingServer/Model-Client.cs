using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace StreamingServer
{
    class Model_Client
    {
        int rc;
        byte[] rb;

        Socket tcpSock;
        public Model_Client(Socket s)
        {
            tcpSock = s; //pass the socket we will be using
        }
        public String rec()
        {
            rb=new byte[1024];
            rc = tcpSock.Receive(rb); //receive a byte arry
            return System.Text.Encoding.UTF8.GetString(rb); //return it as a string
        }
        public void send(String mess)
        {
            rb = System.Text.Encoding.UTF8.GetBytes(mess); //encode a string as byte array
            tcpSock.Send(rb); //send it over the connection
        }
        public bool connected() //check to see if socket is still connected. done in this way so even ungraceful disconnection will be seen
        {
            bool part1 = tcpSock.Poll(1000, SelectMode.SelectRead);
            bool part2 = (tcpSock.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
    }
}
