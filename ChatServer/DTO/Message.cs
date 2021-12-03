using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.DTO
{
    class Message
    {
        public int _Id;
        public string _UserNickName;
        public string _Content;
        public string _MessageDate;

        public Message(int id, string userNickName, string content, string messageDate)
        {
            _Id = id;
            _UserNickName = userNickName;
            _Content = content;
            _MessageDate = messageDate;
        }
    }
}
