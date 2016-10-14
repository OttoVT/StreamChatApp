using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.ClientLib
{
    internal class CallBackHandler : IRoomCallBack
    {
        protected IRoomCallBack roomCallBack;
        public CallBackHandler(IRoomCallBack roomCallBack)
        {
            this.roomCallBack = roomCallBack;
        }
        public void IsWritingCallback(Client client)
        {
            roomCallBack.IsWritingCallback(client);
        }

        public void Receive(Message msg)
        {
            roomCallBack.Receive(msg);
        }

        public void ReceiveFile(FileMessage fileMsg, Client receiver)
        {
            roomCallBack.ReceiveFile(fileMsg, receiver);
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            roomCallBack.ReceiveWhisper(msg, receiver);
        }

        public void RefreshClients(List<Client> clients)
        {
            roomCallBack.RefreshClients(clients);
        }

        public void UserJoin(Client client)
        {
            roomCallBack.UserJoin(client);
        }

        public void UserLeave(Client client)
        {
            roomCallBack.UserLeave(client);
        }
    }
}
