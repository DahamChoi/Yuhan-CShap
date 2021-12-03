using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.DTO
{
    class User
    {
        public int _Uid;
        public string _Id;
        public string _Password;
        public string _Nickname;

        public User(int uid, string id, string password, string nickname)
        {
            _Uid = uid;
            _Id = id;
            _Password = password;
            _Nickname = nickname;
        }
    }
}
