using Microsoft.Practices.ServiceLocation;
using StreamChatApp.Commands;
using StreamChatApp.Model;
using StreamChatApp.Model.Contracts;
using StreamChatApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.ViewModel
{
    public class ChatViewModel : ViewModelBase
    {
        protected ChatModel chatModel;
        public ChatViewModel(ChatModel chatModel)
        {
            this.chatModel = chatModel;
            this.chatModel.CallBackObserver.IsWritingCallbackEvent += IsWritingCallback;
            this.chatModel.CallBackObserver.ReceiveEvent += Receive;
            this.chatModel.CallBackObserver.ReceiveFileEvent += ReceiveFile;
            this.chatModel.CallBackObserver.ReceiveWhisperEvent += ReceiveWhisper;
            this.chatModel.CallBackObserver.RefreshClientsEvent += RefreshClients;
            this.chatModel.CallBackObserver.UserJoinEvent += UserJoin;
            this.chatModel.CallBackObserver.UserLeaveEvent += UserLeave;

            ClientsInRoom = new ObservableCollection<Client>();
            ChatHistory = new ObservableCollection<Message>();

            ConnectToRoom = new DelegateCommand((x) =>
            {
                var window = (ConnectionView)ServiceLocator.Current.GetService(typeof(ConnectionView));
                if (window.ShowDialog().Value == true)
                {
                    //var connectionVM = (window.DataContext as ConnectionViewModel);
                    chatModel.Connect();
                }
            }, null);

            SendMessage = new DelegateCommand((x) =>
            {
                chatModel.Say(MessageText);
            }, null);
        }

        #region Commands
        public DelegateCommand ConnectToRoom { get; set; }
        public DelegateCommand SendMessage { get; set; }
        #endregion

        public string MessageText
        {
            get; set;
        }
        public ObservableCollection<Client> ClientsInRoom { get; }
        public ObservableCollection<Message> ChatHistory { get; protected set; }

        #region Methods
        public void IsWritingCallback(Client client)
        {
            throw new NotImplementedException();
        }

        public void Receive(Message msg)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                ChatHistory.Add(msg);
            });
        }

        public void ReceiveFile(FileMessage fileMsg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void RefreshClients(List<Client> clients)
        {
            ClientsInRoom.Clear();
            clients.ForEach(x => ClientsInRoom.Add(x));
        }

        public void UserJoin(Client client)
        {
            ClientsInRoom.Add(client);
        }

        public void UserLeave(Client client)
        {
            ClientsInRoom.Remove(client);
        }
        #endregion

    }
}
