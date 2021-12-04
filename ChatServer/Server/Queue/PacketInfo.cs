using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatServer.FrameWork.ServerIOFrameWork;

namespace ChatServer.Server.Queue
{
    class PacketInfo
    {
        public StateObject _Handler;
        public string _Packet;

        public PacketInfo(StateObject handler, string packet)
        {
            _Handler = handler;
            _Packet = packet;
        }
    }
}
