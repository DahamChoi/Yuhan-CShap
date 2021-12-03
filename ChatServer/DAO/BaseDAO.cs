using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.DAO
{
    class BaseDAO
    {
        public delegate void OnDatabaseDefaultSuccessCallBack();
        public delegate void OnDatabaseSelectSuccessCallBack<Type>(List<Type> result);
        public delegate void OnDatabaseFailCallBack(string error);
    }

    class Command
    {
        public string _Type;
        public string _Query;
        public BaseDAO.OnDatabaseFailCallBack _OnFailCallBack;

        public Command(string type, string query, BaseDAO.OnDatabaseFailCallBack onFailCallBack)
        {
            _Type = type;
            _Query = query;
            _OnFailCallBack = onFailCallBack;
        }
    }

    class DefaultCommand : Command
    {
        public BaseDAO.OnDatabaseDefaultSuccessCallBack _OnSuccessCallBack;

        public DefaultCommand(string query, BaseDAO.OnDatabaseDefaultSuccessCallBack onSuccessCallBack, BaseDAO.OnDatabaseFailCallBack onFailCallBack)
            : base("default", query, onFailCallBack)
        {
            _OnSuccessCallBack = onSuccessCallBack;
        }
    }

    class SelectCommand<Type> : Command
    {
        public BaseDAO.OnDatabaseSelectSuccessCallBack<Type> _OnSuccessCallBack;

        public SelectCommand(string query, BaseDAO.OnDatabaseSelectSuccessCallBack<Type> onSuccessCallBack, BaseDAO.OnDatabaseFailCallBack onFailCallBack) : base(typeof(Type).Name, query, onFailCallBack)
        {
            _OnSuccessCallBack = onSuccessCallBack;
        }
    }
}
