using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Server.Queue
{
    class DatabaseCallBack
    {
        public delegate void CallBack();

        public CallBack _CallBack;

        public DatabaseCallBack(CallBack callBack)
        {
            _CallBack = callBack;
        }
    }
}
