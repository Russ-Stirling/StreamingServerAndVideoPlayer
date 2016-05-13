using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace StreamingServer
{
    class Model_RTP
    {
        public class RTP_Packet
        {
            int version;
            int p;
            int x;
            int cc;
            int m;
            int pT;
            int seqNum;
            long timeStamp;
            long ourCsrc;
            
            public RTP_Packet()
            {
                Random v = new Random();
                seqNum = v.Next(); //create random seq num
                version = 2;
                p = 0;
                x = 0;
                cc = 0;
                m = 0;
                pT = 26;
                timeStamp = 1;
                ourCsrc = 4321;
            }
            public byte[] getHeader()
            {
                byte[] packet = new byte[12]; //allocate this big enough to hold the RTP header + audio data
                //assemble the first bytes according to the RTP spec (note, the spec marks version as bit 0 and 1, but
                //this is really the high bits of the first byte ...
                packet[0] = (byte)((version & 0x3) << 6 | (p & 0x1) << 5 | (x & 0x1) << 4 | (cc & 0xf));

                //2.byte
                packet[1] = (byte)((m & 0x1) << 7 | pT & 0x7f);

                //squence number, 2 bytes, in big endian format. So the MSB first, then the LSB.
                packet[2] = (byte)((seqNum & 0xff00) >> 8);
                packet[3] = (byte)(seqNum & 0x00ff);

                //packet timestamp , 4 bytes in big endian format
                packet[4] = (byte)((timeStamp & 0xff000000) >> 24);
                packet[5] = (byte)((timeStamp & 0x00ff0000) >> 16);
                packet[6] = (byte)((timeStamp & 0x0000ff00) >> 8);
                packet[7] = (byte)(timeStamp & 0x000000ff);
                //our CSRC , 4 bytes in big endian format
                packet[8] = (byte)((seqNum & 0xff000000) >> 24);
                packet[9] = (byte)((seqNum & 0x00ff0000) >> 16);
                packet[10] = (byte)((seqNum & 0x0000ff00) >> 8);
                packet[11] = (byte)(seqNum & 0x000000ff);
                return packet;
            }
            public byte[] getPacket(byte[] sendingFrame)
            {
                byte[] packet = new byte[12+sendingFrame.Length]; //allocate this big enough to hold the RTP header + audio data
                //assemble the first bytes according to the RTP spec (note, the spec marks version as bit 0 and 1, but
                //this is really the high bits of the first byte ...
                packet[0] = (byte)((version & 0x3) << 6 | (p & 0x1) << 5 | (x & 0x1) << 4 | (cc & 0xf));

                //2.byte
                packet[1] = (byte)((m & 0x1) << 7 | pT & 0x7f);

                //squence number, 2 bytes, in big endian format. So the MSB first, then the LSB.
                packet[2] = (byte)((seqNum & 0xff00) >> 8);
                packet[3] = (byte)(seqNum & 0x00ff);

                //packet timestamp , 4 bytes in big endian format
                packet[4] = (byte)((timeStamp & 0xff000000) >> 24);
                packet[5] = (byte)((timeStamp & 0x00ff0000) >> 16);
                packet[6] = (byte)((timeStamp & 0x0000ff00) >> 8);
                packet[7] = (byte)(timeStamp & 0x000000ff);
                //our CSRC , 4 bytes in big endian format
                packet[8] = (byte)((seqNum & 0xff000000) >> 24);
                packet[9] = (byte)((seqNum & 0x00ff0000) >> 16);
                packet[10] = (byte)((seqNum & 0x0000ff00) >> 8);
                packet[11] = (byte)(seqNum & 0x000000ff);
                
                int index = 12;
                foreach (byte b in sendingFrame) //add the frame to the packet
                {
                    packet[index] = b;
                    index++;
                }
                timeStamp = timeStamp + 100; //increment timeStamp and seq num
                seqNum++; 
                return packet; //return the packet
            }
        }

        IPEndPoint ep;
        IPAddress ip;
        Socket udpSock;
        byte[] vid;
        int port, frameNum=0;
        FileStream fs;
        RTP_Packet rtp;

        public Model_RTP()
        {
            rtp = new RTP_Packet(); //create an rtp packet class
        }
        public void setInfo(int _port, String _ip, String _path) //set the rtp info
        {
            udpSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //make a udp socket
            port = _port; //set port, ip and endpoint
            ip = IPAddress.Parse(_ip);
            ep = new IPEndPoint(ip, port);
            fs = null; //ensure filestream is empty then open the requested file as read only
            fs = File.OpenRead("C:\\Users\\rusty_000\\Documents\\Visual Studio 2012\\Projects\\3314Assignment1\\StreamingServer\\Resources\\"+_path);
            frameNum = 0; //set frame num to 0
        }
        public String getHead() //get the rtp header as a string
        {
            byte[] header = rtp.getHeader(); //get the most recent header
            var bits = new System.Collections.BitArray(header); //convert it to a bit array
            String res = ""; //initialize a string for the bits
            
            for (int i = 0; i < bits.Length; i++)
            {
                res += bits.Get(i) ? "1" : "0"; //add bits to the string as a 1 or 0

                // Output a space every 8 characters.
                if ((i + 1) % 8 == 0)
                {
                    res += " ";
                }
            }
            return res; //return the string
        }

        public String getFrameNum() //well, it gets the frame number....
        {
            return frameNum.ToString();
        }
        public byte[] getFrame() //get the frame bytes
        {
            vid = new byte[5];
            fs.Read(vid, 0, 5); //read first 5 bytes to vid
            int size = Int32.Parse(System.Text.Encoding.UTF8.GetString(vid)); //get the size of the frame from vid
            vid = new byte[size]; //turn vid into a new byte array the size of the frame
            fs.Read(vid, 0, size); //read the frame into vid
            vid = rtp.getPacket(vid); //call packet command to add header to vid
            frameNum++; //increment the frame number
            return vid; //return the byte array with the packet
        }

        public void send(byte[] packet) //send a byte array across the udp socket
        {
            udpSock.SendTo(packet, ep);
        }
        public void teardown() //close the udp socket and the file that is open
        {
            udpSock.Close();
            fs.Close();
        }
    }
}
