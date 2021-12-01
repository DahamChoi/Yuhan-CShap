using ChatServer.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        public static int Main(String[] args)
        {
            Thread IOThread = new Thread(() =>
            {
                ServerIOFrameWork serverIOFrameWork = new ServerIOFrameWork(10);
                serverIOFrameWork.MainWork();
            });

            Thread DatabaseThread = new Thread(() =>
            {
                DatabaseFrameWork databaseFrameWork = new DatabaseFrameWork(10);
                databaseFrameWork.MainWork();
            });

            Thread PacketRecieveThread = new Thread(() =>
            {
                PacketRecieveFrameWork packetRecieveFrameWork = new PacketRecieveFrameWork(10);
                packetRecieveFrameWork.MainWork();
            });

            Thread DatabaseCallBackThread = new Thread(() =>
            {
                DatabaseCallBackFrameWork databaseCallBackFrameWork = new DatabaseCallBackFrameWork(10);
                databaseCallBackFrameWork.MainWork();
            });

            IOThread.Start();
            DatabaseThread.Start();
            PacketRecieveThread.Start();
            DatabaseCallBackThread.Start();

            IOThread.Join();
            DatabaseThread.Join();
            PacketRecieveThread.Join();
            DatabaseCallBackThread.Join();

            return 0;
        }
    }
}
