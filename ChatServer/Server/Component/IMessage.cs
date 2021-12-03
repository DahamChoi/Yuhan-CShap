using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Server.Component
{
    interface IMessage
    {
        void GetMessage(Socket handler, int from, int to);
        void SendMessage(Socket hanlder, string nickname, string content);
    }
}
