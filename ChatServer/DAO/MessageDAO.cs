using ChatServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatServer.DAO.BaseDAO;

namespace ChatServer.DAO
{
    class MessageDAO
    {
        public static void InsertMessage(string nickname, string content, OnDatabaseDefaultSuccessCallBack onSuccessCallBack, OnDatabaseFailCallBack onFailCallBack)
        {
            string query = "insert into message(user_nickname, content, message_date)" +
                "values('" + nickname + "','" + content + "',now());";

            ThreadQueue<Command>.Instance.InsertQueue(new DefaultCommand(query, onSuccessCallBack, onFailCallBack));
        }

        public static void SelectMessage(int from, int to, OnDatabaseSelectSuccessCallBack<Message> onSuccessCallBack, OnDatabaseFailCallBack onFailCallBack)
        {
            string query = "select * from message order by message_date desc limit " + from + "," + to + ";";

            ThreadQueue<Command>.Instance.InsertQueue(new SelectCommand<Message>(query, onSuccessCallBack, onFailCallBack));
        }
    }
}
