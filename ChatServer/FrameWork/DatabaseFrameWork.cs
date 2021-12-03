using ChatServer.DAO;
using ChatServer.Database;
using ChatServer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ChatServer.Server.Queue.DatabaseCallBack;

namespace ChatServer.FrameWork
{
    class DatabaseFrameWork : FrameWork
    {
        public DatabaseFrameWork(int sleep) : base(sleep) { }

        private DatabaseController _DatabaseController = new DatabaseController();

        protected override void BeginWork()
        {

        }

        protected override void EndWork()
        {

        }

        protected override void MainWorkImpl()
        {
            var queue = ThreadQueue<Command>.Instance.GetQueue();
            while (0 != queue.Count)
            {
                var top = queue.Dequeue();

                if (top._Type == "default")
                {
                    var defaultCommand = (DefaultCommand)top;
                    try
                    {
                        _DatabaseController.ExcuteQuery(defaultCommand._Query);
                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            defaultCommand._OnSuccessCallBack.Invoke();
                        });
                    }
                    catch (Exception e)
                    {
                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            defaultCommand._OnFailCallBack(e.Message);
                        });
                    }
                }
                else if (top._Type == "class SelectCommand<User>")
                {
                    var userSelectCommand = (SelectCommand<User>)top;
                    try
                    {
                        var result = _DatabaseController.ExcuteSelectQuery(top._Query);
                        List<User> ret = new List<User>();
                        foreach (DataRow r in result.Tables[0].Rows)
                        {
                            ret.Add(
                                new User((int)r["uid"], (string)r["id"], (string)r["password"], (string)r["nickname"]));
                        }

                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            userSelectCommand._OnSuccessCallBack.Invoke(ret);
                        });
                    }
                    catch (Exception e)
                    {
                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            userSelectCommand._OnFailCallBack(e.Message);
                        });
                    }
                }
                else if (top._Type == "class SelectCommand<Message>")
                {
                    var messageSelectCommand = (SelectCommand<Message>)top;
                    try
                    {
                        var result = _DatabaseController.ExcuteSelectQuery(top._Query);
                        List<Message> ret = new List<Message>();
                        foreach (DataRow r in result.Tables[0].Rows)
                        {
                            ret.Add(
                                new Message((int)r["id"], (string)r["user_nickname"], (string)r["content"], (string)r["message_date"]));
                        }

                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            messageSelectCommand._OnSuccessCallBack.Invoke(ret);
                        });
                    }
                    catch (Exception e)
                    {
                        ThreadQueue<CallBack>.Instance.InsertQueue(() =>
                        {
                            messageSelectCommand._OnFailCallBack(e.Message);
                        });
                    }
                }
            }
        }
    }
}
