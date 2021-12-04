using ChatServer.DAO;
using ChatServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static ChatServer.FrameWork.ServerIOFrameWork;

namespace ChatServer.Server.Component
{
    class UserComponent : IUser
    {
        public void Login(Socket handler, string id, string password)
        {
            UserDAO.SelectUserByIdPassword(id, password, (List<User> result) =>
            {
                if(result.Count == 0)
                {
                    string failPacket = "LoginFail;";
                    AsynchronousSocketListener.Send(handler, failPacket);
                    return;
                }

                string packet = "LoginSuccess;";
                AsynchronousSocketListener.Send(handler, packet);
            },
            (string error) =>
            {
                Console.WriteLine(error);
            });
        }

        public void SignUp(Socket handler, string id, string password, string nickname)
        {
            UserDAO.InsertUser(id, password, nickname, () =>
            {
                string packet = "SignUpSuccessPacket;";
                AsynchronousSocketListener.Send(handler, packet);
            },
            (string error) =>
            {
                Console.WriteLine(error);
            });
        }
    }
}
