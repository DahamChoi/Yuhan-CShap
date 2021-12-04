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
    class MessageComponent : IMessage
    {
        public void GetMessage(Socket handler, int from, int to)
        {
            MessageDAO.SelectMessage(from, to, (List<Message> result) =>
            {
                // Not Impl
            },
            (string error) =>
            {
                Console.WriteLine(error);
            });
        }

        public void SendMessage(Socket hanlder, string nickname, string content)
        {
            MessageDAO.InsertMessage(nickname, content, () =>
            {
                var socketList = AsynchronousSocketListener.GetStateObject();
                foreach(var socket in socketList)
                {
                    string packet = $"ReceiveMessage;{nickname};{content};<EOF>";
                    AsynchronousSocketListener.Send(socket.workSocket, packet);
                }
            },
            (string error) =>
            {
                Console.WriteLine(error);
            });
        }
    }
}
