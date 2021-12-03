using System;
using static ChatServer.Server.Queue.DatabaseCallBack;

namespace ChatServer.FrameWork
{
    class DatabaseCallBackFrameWork : FrameWork
    {
        public DatabaseCallBackFrameWork(int sleep) : base(sleep) { }

        protected override void BeginWork()
        {
            ;
        }

        protected override void EndWork()
        {
            ;
        }

        protected override void MainWorkImpl()
        {
            var queue = ThreadQueue<CallBack>.Instance.GetQueue();
            while (0 != queue.Count)
            {
                var top = queue.Dequeue();
                top.Invoke();
            }
        }
    }
}
