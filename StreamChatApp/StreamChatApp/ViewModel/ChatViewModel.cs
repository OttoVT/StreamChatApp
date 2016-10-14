using StreamChatApp.Model;
using StreamChatApp.Model.Contracts;
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
        }

        public ObservableCollection<Client> ClientsInRoom { get; }
        public ObservableCollection<Message> ChatHistory { get; protected set; }

        public void IsWritingCallback(Client client)
        {
            throw new NotImplementedException();
        }

        public void Receive(Message msg)
        {
            ChatHistory.Add(msg);
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
    }
}
