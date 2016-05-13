using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayer
{
    class RTP_Packet
    {
        const int headSize = 12; //the standard header size
        int packetSize;
        byte[] header;
        byte[] packet;

        public RTP_Packet(byte[] _packet)
        {
            packetSize = _packet.Length - 12; //the size of the frame
            header = new byte[12];
            packet = new byte[packetSize];
            for (int i = 0; i < 12; i++) //store header info in header array
            {
                header[i] = _packet[i];
            }
            int j = 0;
            for (int i = 12; i < _packet.Length; i++) //store frame info in packet array
            {
                packet[j] = _packet[i];
                j++;
            }
        }
        public byte[] getFrame()
        {
            return packet; //get the frame
        }
        public int getSeq() //get the sequence number which is made up of data at positions 3 and 2 in header
        {
            int i, j;
            i = header[3];
            j = header[2]*256;
            Console.WriteLine(i + j);
            return i+j;
        }
        public int getTime() //get the timestamp number which is made up of data at positions 7,6,5 and 4 in header
        {
            int i,j,k,l;
            i = header[7];
            j = header[6] * 256;
            k = header[5] * 65536;
            l = header[4] * 16777216;
            Console.WriteLine(((i + j) + k) + l);

            return (((i+j)+k)+l);

        }
        public int getType() //get the type number which is made up of data at positions 1 in header
        {
            int i = (header[1] & 0x7f);
            Console.WriteLine(i);
            return i;
        }
        public String getHead() //get the rtp header as a string
        {
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

    }
}
