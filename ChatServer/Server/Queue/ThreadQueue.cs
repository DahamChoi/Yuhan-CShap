using ChatServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    sealed class ThreadQueue<Type> : Singleton<ThreadQueue<Type>>
    {
        private Queue<Type> _Queue = new Queue<Type>();
        private readonly object _Mutex = new object();

        public Queue<Type> GetQueue()
        {
            lock(_Mutex)
            {
                var ret = new Queue<Type>(_Queue);
                _Queue.Clear();
                return ret;
            }
        }

        public void InsertQueue(Type item)
        {
            lock(_Mutex)
            {
                _Queue.Enqueue(item);
            }
        }
    }
}
