using StreamChatApp.Communication.CallBackInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using StreamChatApp.Communication.ServerInterface;
using StreamChatApp.Communication.BLLInterfaces;

namespace StreamChatApp.Communication.ClientLib
{
    public class RoomClient : IDisposable, IRoomClient
    {
        protected InstanceContext instanceContext;
        protected IRoomService roomService;
        protected ICallBackObserver callBackObserver;
        protected IUserContext userContext;
        private DuplexChannelFactory<IRoomService> factory;

        public RoomClient(ICallBackObserver callBackObserver, IUserContext userContext)
        {
            this.userContext = userContext;
            userContext.CurrentUser = new Client()
            {
                ClientId = new Guid(),
                Name = "User1",
                OpenKey = "",
                Time = DateTime.Now
            };
            this.callBackObserver = callBackObserver;
            this.instanceContext = new InstanceContext(new CallBackHandler(this.callBackObserver));
        }
        public ICallBackEvents CallBackObserver { get { return callBackObserver; } }

        #region Methods
        public void SetCurrentUser(Client client)
        {
            userContext.CurrentUser = client;
        }

        public void Connect(string address)
        {
            NetTcpBinding tcpb = new NetTcpBinding();
            factory = new DuplexChannelFactory<IRoomService>(instanceContext, tcpb);

                factory.Endpoint.Address = new EndpointAddress(address);
            this.roomService = factory.CreateChannel();
            this.roomService.Connect(userContext.CurrentUser);

        }

        public void Disconnect()
        {
            this.roomService.Disconnect(userContext.CurrentUser);
        }

        public void Say(Message msg)
        {
            roomService.Say(msg);
        }

        public void Whisper(Message msg, Client receiver)
        {
            roomService.Whisper(msg, receiver);
        }

        public void IsWriting()
        {
            roomService.IsWriting(userContext.CurrentUser);
        }

        public bool SendFile(FileMessage fileMsg, Client receiver)
        {
            return roomService.SendFile(fileMsg, receiver);
        }

        public void Dispose()
        {
            Disconnect();
            //TODO: unregister all;
            callBackObserver?.Unsubscribe();
            factory.Close();
            instanceContext.Close();
        }
        #endregion
    }
}
