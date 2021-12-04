using ChatServer.Server.Component;
using ChatServer.Server.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.FrameWork
{
    class PacketRecieveFrameWork : FrameWork
    {
        private List<IUser> _UserComponentList = new List<IUser>();
        private List<IMessage> _MessageComponentList = new List<IMessage>();

        public PacketRecieveFrameWork(int sleep) : base(sleep) { }

        protected override void BeginWork()
        {
            _UserComponentList.Add(new UserComponent());
            _MessageComponentList.Add(new MessageComponent());
        }

        protected override void EndWork()
        {

        }

        protected override void MainWorkImpl()
        {
            var queue = ThreadQueue<PacketInfo>.Instance.GetQueue();
            while(queue.Count != 0)
            {
                var top = queue.Dequeue();
                string[] array = top._Packet.Split(';');
                if (array[0] == "SignUp")
                {
                    foreach(var it in _UserComponentList)
                    {
                        it.SignUp(
                            top._Handler.workSocket, array[1], array[2], array[3]);
                    }
                }
                else if (array[0] == "Login")
                {
                    foreach(var it in _UserComponentList)
                    {
                        it.Login(top._Handler.workSocket, array[1], array[2]);
                    }
                }
                else if (array[0] == "SendMessage")
                {
                    foreach(var it in _MessageComponentList)
                    {
                        it.SendMessage(top._Handler.workSocket, array[1], array[2]);
                    }
                }
                else if (array[0] == "GetMessage")
                {
                    foreach(var it in _MessageComponentList)
                    {
                        it.GetMessage(top._Handler.workSocket, int.Parse(array[1]), int.Parse(array[2]));
                    }
                }
            }
        }
    }
}
