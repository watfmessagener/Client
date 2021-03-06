﻿using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace sp
{
    public partial class Client
    {

        public class ActionClient : IActionClient
        {

            public MainWindow window;
            private Xml xml;
            public Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;
            Socket socketSend, socketRecv;
            string ip { get; set; }
            int port;
            uint ID;
            public string login;


            public ActionClient(MainWindow window , uint id,string login)
            {
                xml = new Xml("config.xml");
                this.window = window;
                SetConfig();
                listenMesg();
                ID = id;
                this.login = login;
            }
            public void SetConfig()
            {
                this.ip = xml.getIpfromXML();
                this.port = xml.getPortfromXML();

            }
            public uint getId()
            {
                return ID;
            }
            
            public void disconnectFromserver()
            {
                CPS message = new CPS(MegType.DISCONNECT);
                message.info.MSG_LEN = 0;
                message.MSG = "none";
                message.info.ID_DEST = 0;
                message.info.ID_SRC = this.ID;
                socketSend = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socketSend.Connect(ip, port);
                    socketSend.Send(message.StructToBytes());
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("Eror send message");
                }
                socketSend.Close();
            }
            public void sendMessage(string message, uint ID_DEST)
            {
                CPS watfMessage = new CPS(MegType.MESSAGE);
                watfMessage.info.MSG_LEN = message.Length;
                watfMessage.MSG = message;
                watfMessage.info.ID_DEST = ID_DEST;
                watfMessage.info.ID_SRC = this.ID;
                socketSend = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    
                    
                    socketSend.Connect(ip, port);
                    socketSend.Send(watfMessage.StructToBytes());
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("Eror send message");
                }
                socketSend.Close();
            }


            public void SendSearchFriend(string name)
            {
                if(name.Length < 3)
                {
                    return;
                }
                CPS message = new CPS(MegType.SEARCHUSER);
                message.info.MSG_LEN = name.Length;
                message.info.ID_SRC = ID;
                message.info.ID_DEST = 0;
                message.MSG = name;
                socketSend = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socketSend.Connect(ip, port);
                    socketSend.Send(message.StructToBytes());
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("Eror send message");
                }
                socketSend.Close();
            }

            public void SendRequestOnFriend(string name, uint id)
            {
                CPS message = new CPS(MegType.REQUESTONFRIEND);
                message.info.MSG_LEN = name.Length;
                message.info.ID_SRC = ID;
                message.info.ID_DEST = id;
                message.MSG = name;
                socketSend = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socketSend.Connect(ip, port);
                    socketSend.Send(message.StructToBytes());
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("Eror send message");
                }
                socketSend.Close();
            }


            public void SendAcceptOnFriend(string name, uint id)
            {
                CPS message = new CPS(MegType.ACCEPTONFRIEND);
                message.info.MSG_LEN = name.Length;
                message.info.ID_SRC = ID;
                message.info.ID_DEST = id;
                message.MSG = name;
                socketSend = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socketSend.Connect(ip, port);
                    socketSend.Send(message.StructToBytes());
                }
                catch (SocketException e)
                {
                    // Console.WriteLine("Eror send message");
                }
                socketSend.Close();
            }


            public void listenMesg()
            {
                Task t = Task.Run(() => listenMesgThread());
            }
            public void listenMesgThread() // подключаем слушающий сокет
            {
                CPS watfMessage = new CPS(100);
                CPS newmessage = new CPS();
                byte[] buffer = new byte[1024];
                socketRecv = new Socket(SocketType.Stream, ProtocolType.Tcp);
                if (ID == 0)  // проверяем, есть ли у нас ID
                {
                    watfMessage = new CPS(MegType.REGISTRATION);
                    watfMessage.MSG = "registration";
                }
                else  // если есть то отправляем его на сервер
                {
                    this.Dispatcher.BeginInvoke(new Action(() => window.SetMyLogin(login)));
                    watfMessage = new CPS(MegType.CONNECT);
                    watfMessage.info.ID_SRC = ID;
                    watfMessage.MSG = login;                  
                }
                byte[] recvmessange = new byte[520];
                try
                {
                    socketRecv.Connect(ip, port);
                    byte[] bytemessange = watfMessage.StructToBytes();
                    socketRecv.Send(bytemessange);
                }
                catch (SocketException e)
                {
                    this.Dispatcher.Invoke(new Action(() => window.SetLoginStatus(false)));
                    socketRecv.Close();
                    return;
                }
                this.Dispatcher.Invoke(new Action(() => window.SetLoginStatus(true)));


                while (true)
                {
                    try
                    {
                       
                        int length = socketRecv.Receive(buffer);
                        MessageHandler messageHandler = new MessageHandler(window,Dispatcher,buffer, length);

                        
                    }
                    catch (SocketException e)
                    {
                        this.Dispatcher.Invoke(new Action(() => window.SetLoginStatus(false)));
                        // Console.WriteLine("Eror listen message");
                        socketRecv.Close();
                        return;
                    }

                }
            }
            public uint getIDfromByte(byte[] arr)
            {
                CPS message = new CPS();
                uint id;
                message.BytesToStruct(arr);
                id = message.info.ID_SRC;
                return id;
            }
        }
    }
}
