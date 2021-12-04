using ChatServer.DTO;
using static ChatServer.DAO.BaseDAO;

namespace ChatServer.DAO
{
    class UserDAO
    {
        public static void InsertUser(string id, string password, string nickname, OnDatabaseDefaultSuccessCallBack onSuccessCallBack, OnDatabaseFailCallBack onFailCallBack)
        {
            string query = $"insert into user(id, password, nickname) values('{id}','{password}','{nickname}');";

            ThreadQueue<Command>.Instance.InsertQueue(new DefaultCommand( query, onSuccessCallBack, onFailCallBack ));
        }

        public static void SelectUserByIdPassword(string id, string password, OnDatabaseSelectSuccessCallBack<User> onSuccessCallBack, OnDatabaseFailCallBack onFailCallBack)
        {
            string query = $"select * from user where id = '{id}' and password = '{password}';";
            ThreadQueue<Command>.Instance.InsertQueue(new SelectCommand<User>(query, onSuccessCallBack, onFailCallBack));
        }
    }
}
