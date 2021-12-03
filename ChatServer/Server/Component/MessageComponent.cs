using ChatServer.DAO;
using ChatServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Server.Component
{
    class MessageComponent : IMessage
    {
        public void GetMessage(Socket handler, int from, int to)
        {
            MessageDAO.SelectMessage(from, to, (List<Message> result) =>
            {

            },
            (string error) =>
            {

            });
        }

        public void SendMessage(Socket hanlder, string nickname, string content)
        {
            throw new NotImplementedException();
        }
    }
}
