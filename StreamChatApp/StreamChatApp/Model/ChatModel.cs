using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using StreamChatApp.Communication.ClientLib;
using StreamChatApp.Communication.BLLInterfaces;

namespace StreamChatApp.Model
{
    public class ChatModel
    {
        private IRoomClient roomClient;
        private IConfiguration configuration;
        private IUserContext userContext;
        public ChatModel(IRoomClient roomClient, IConfiguration configuration, IUserContext userContext)
        {
            this.roomClient = roomClient;
            this.configuration = configuration;
            this.userContext = userContext;
        }

        public ICallBackEvents CallBackObserver { get { return this.roomClient.CallBackObserver; }  }

        public void Connect()
        {
            var ip = configuration.RoomIpAddress;
            roomClient.Connect(ip);
        }

        public void Disconnect()
        {
            roomClient.Disconnect();
        }

        public void IsWriting()
        {
            roomClient.IsWriting();
        }

        public void Say(string text)
        {
            var msg = new Message()
            {
                Content = text,
                Sender = userContext.CurrentUser.Name,
                SenderId = userContext.CurrentUser.ClientId,
                Time = DateTime.UtcNow,
            };
            roomClient.Say(msg);
        }

        public bool SendFile(FileMessage fileMsg, Client receiver)
        {
            return roomClient.SendFile(fileMsg, receiver);
        }

        public void SetCurrentUser(Client client)
        {
            roomClient.SetCurrentUser(client);
        }

        public void Whisper(Message msg, Client receiver)
        {
            roomClient.Whisper(msg, receiver);
        }
    }
}
