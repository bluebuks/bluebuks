using System;
using System.Net.Sockets;

namespace QuantX
{
    

    public class state
    {
        public byte[] buffer = new byte[0xfa00];
        public readonly int bufferSize = 0xfa00;
        public DateTime dtLastPacketTime;
        public int index;
        public string sClientID;
        public string tag;
        public Socket wSocket;
    }
}

