using StreamChatApp.Communication.ServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using System.ServiceModel;
using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Communication.BLL.Logic;
using StreamChatApp.Communication.BLLInterfaces;

namespace StreamChatApp.Communication.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class RoomService : IRoomService
    {
        private readonly IRoomContext roomContext;

        public RoomService(IRoomContext roomContext)
        {
            this.roomContext = roomContext;
        }

        public IRoomCallBack CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IRoomCallBack>();
            }
        }
        public bool Connect(Model.Contracts.Client client)
        {
            var request = new BLLRequestContext<Client>()
            {
                CallBack = CurrentCallback,
                Context = client,
            };

            return roomContext.Connect(request);
        }

        public void Disconnect(Model.Contracts.Client client)
        {
            var request = new BLLRequestContext<Client>()
            {
                CallBack = CurrentCallback,
                Context = client,
            };

            roomContext.Disconnect(request);
        }

        public void IsWriting(Model.Contracts.Client client)
        {
            var request = new BLLRequestContext<Client>()
            {
                CallBack = CurrentCallback,
                Context = client,
            };

            roomContext.IsWriting(request);
        }

        public void Say(Message msg)
        {
            var request = new BLLRequestContext<Message>()
            {
                CallBack = CurrentCallback,
                Context = msg,
            };

            roomContext.Say(request);
        }

        public bool SendFile(FileMessage fileMsg, Model.Contracts.Client receiver)
        {
            return roomContext.SendFile(fileMsg, receiver);
        }

        public void Whisper(Message msg, Model.Contracts.Client receiver)
        {
            roomContext.Whisper(msg, receiver);
        }
    }
}
