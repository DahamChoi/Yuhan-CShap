using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer.FrameWork
{
    abstract class FrameWork
    {
        private int _Sleep = 0;
        private bool _IsEnd { get; set; } = false;

        public FrameWork(int sleep)
        {
            _Sleep = sleep;
        }

        protected abstract void BeginWork();
        protected abstract void EndWork();
        protected abstract void MainWorkImpl();

        public void MainWork()
        {
            BeginWork();

            while(false == _IsEnd)
            {
                MainWorkImpl();

                if(_Sleep > 0)
                {
                    Thread.Sleep(_Sleep);
                }
            }

            EndWork();
        }
    }
}
