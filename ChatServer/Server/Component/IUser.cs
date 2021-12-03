using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Server.Component
{
    interface IUser
    {
        void SignUp(Socket handler, string id, string password, string nickname);
        void Login(Socket handler, string id, string password);
    }
}
