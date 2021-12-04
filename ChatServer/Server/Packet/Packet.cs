using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Server.Packet
{
    /*
     * 기본 패킷 정의
     *  -> string형태를 기본으로 패킷을 주고 받고 ;(세미콜론)을 기준으로 각각의 칼럼을 구별한다.
     *  
     * SignUpPacket
     *  -> SignUp;{id};{password};{nickname};
     *  
     *  SignUpSuccessPacket
     *  -> SignUpSuccess;
     * 
     * LoginPacket
     *  -> Login;{id};{password};
     * 
     * LoginSuccessPacket
     *  -> LoginSuccess;{nickname};
     *  
     *  LoginFailPacket
     *   -> LoginFail;
     * 
     * SendMessage
     *  -> SendMessage;{nickname};{content};
     * 
     * SendMessageSuccess
     *  -> SendMessageSuccess;
     * 
     * ReceiveMessage
     *  -> ReceiveMessage;{nickname};{content};
     * 
     * GetMessage
     *  -> GetMessage;{from};{to};
     * 
     * GetMessageSuccess
     *  -> GetMessageSuccess;{size};[{nickname},{content},{date}];
     * 
     */

    class SignUpPacket
    {
        public string _Id;
        public string _Password;
        public string _NickName;

        public SignUpPacket(string id, string password, string nickName)
        {
            _Id = id;
            _Password = password;
            _NickName = nickName;
        }
    }

    class LoginPacket
    {
        public string _Id;
        public string _Password;

        public LoginPacket(string id, string password)
        {
            _Id = id;
            _Password = password;
        }
    }

    class GetMessagePacket
    {
        public int _From;
        public int _To;

        public GetMessagePacket(int from, int to)
        {
            _From = from;
            _To = to;
        }
    }

    class SendMessagePacket
    {
        public string _NickName;
        public string _Content;

        public SendMessagePacket(string nickName, string content)
        {
            _NickName = nickName;
            _Content = content;
        }
    }

    class ReceiveMessagePacket
    {
        public string _NickNAme;
        public string _Content;

        public ReceiveMessagePacket(string nickNAme, string content)
        {
            _NickNAme = nickNAme;
            _Content = content;
        }
    }
}
