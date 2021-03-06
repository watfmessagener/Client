﻿using System.Windows.Controls;
using System;
using System.Windows;
using System.IO;

namespace UserChat
{

    public partial class Userchat : UserControl
    {
        private string Nick;
        private uint ID;
        bool online;

        public Userchat()
        {
            InitializeComponent();
            ID = 0;
            ReadMsgHistory();
        }
        public Userchat(string name,uint id)
        {
            InitializeComponent();
            FirstName.Text = name;
            ID = id;
            ReadMsgHistory();
        }

        public void setConnected(bool st)
        {
            if (st)
            {
                online = true;
                indicatorOnline.Visibility = Visibility.Visible;
                indicatorOffline.Visibility = Visibility.Hidden;

            }
            else
            {
                online = false;
                indicatorOffline.Visibility = Visibility.Visible;
                indicatorOnline.Visibility = Visibility.Hidden;
            }
        }

        public void setID(uint ID)
        {
            this.ID = ID;
        }
        public uint getID()
        {
            return ID;
        }
        public void Copy(Userchat copy)
        {
            FirstName.Text = copy.FirstName.Text;
            MessageList.Text = copy.MessageList.Text;
            Avatar = copy.Avatar;
            online = copy.online;
            setConnected(online);
            ID = copy.ID;
        }
        public void setText(string text)
        {
            FirstName.Text = text;
        }

        public string getNewMessage()
        {
            return NewmessageBox.Text;
        }

        public void clearNewMessageBox()
        {
            NewmessageBox.Clear();
        }

        public void AddMessagetoMessageList(string userNick, string message)
        {
            int size = userNick.Length;
            int lengtnewNick=0;

            while(size!=0)
            {
                if (userNick[size - 1] != '\n' && userNick[size - 1] != '\0')
                    lengtnewNick++;

                size--;
            }
           
            string newnick = userNick.Substring(0, lengtnewNick);
            MessageList.Text += Environment.NewLine + newnick + " : " + message;
            
        }

        public void ReadMsgHistory()
        {
            try
            {
                StreamReader Rfile = new StreamReader("data/" + ID.ToString() + ".mh");
                MessageList.Text = Rfile.ReadToEnd();
                Rfile.Close();
            }
            catch (Exception e)
            {

            }

        }

        public string getMsgHistory()
        {
            return MessageList.Text;
        }

        public event EventHandler<ChatItemcontrolArgs> ClickCall; // объявляем событие
        public event EventHandler<ChatItemcontrolArgs> ClickMessage; // объявляем событие
        public event EventHandler<ChatItemcontrolArgs> ClickSend; // объявляем событие
        public event EventHandler<ChatItemcontrolArgs> ClickSmile; // объявляем событие
        public event EventHandler<ChatItemcontrolArgs> EnterSend; // объявляем событие

        protected void RaiseEnterSend(string name)
        {
            if (EnterSend != null)
            {
                EnterSend(this, new ChatItemcontrolArgs(name));
            }
        } // Метод который вызывает событие
        protected void RaiseCallClick(string name)
        {
            if (ClickCall != null)
            {
                ClickCall(this, new ChatItemcontrolArgs(name));
            }
        } // Метод который вызывает событие

        protected void RaiseMessageClick(string name) // Метод который вызывает событие
        {
            if (ClickMessage != null)
            {
                ClickMessage(this, new ChatItemcontrolArgs(name));
            }
        }

        protected void RaiseSendClick(string name)
        {
            if (ClickSend != null)
            {
                ClickSend(this, new ChatItemcontrolArgs(name));
            }
        } // Метод который вызывает событие

        protected void RaiseSmileClick(string name)
        {
            if (ClickSmile != null)
            {
                ClickSmile(this, new ChatItemcontrolArgs(name));
            }
        } // Метод который вызывает событие

        private void PART_call_Click(object sender, RoutedEventArgs e)
            // Стандартное событие нажатия на кнопку, которое вызывает  RaiseCallClick();
        {
            RaiseCallClick(FirstName.Text);
        }

        private void PART_message_Click(object sender, RoutedEventArgs e)
            // Стандартное событие нажатия на кнопку, которое вызывает RaiseMessageClick();
        {
            RaiseMessageClick(FirstName.Text);
        }


        private void Bsend_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseSendClick(FirstName.Text);
        }

        private void Bsmile_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseSmileClick(FirstName.Text);
        }

        private void MessageList_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageList.ScrollToEnd();
        }

        private void NewmessageBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                RaiseSendClick(FirstName.Text);
            }
        }

        private void MessageList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }
    }

    public class ChatItemcontrolArgs : EventArgs // класс которые мы передаём в качестве параметра события
    {
        public ChatItemcontrolArgs(string name)
        {
            this.name = name;
        }

        public string name { private set; get; }
    }
}

