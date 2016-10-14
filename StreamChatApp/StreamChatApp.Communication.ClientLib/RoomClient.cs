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
        protected Client currentUser;
        protected IUserContext userContext;

        public RoomClient(ICallBackObserver callBackObserver, IUserContext userContext)
        {
            this.userContext = userContext;
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
            using (DuplexChannelFactory<IRoomService> factory
                = new DuplexChannelFactory<IRoomService>(instanceContext, tcpb))
            {
                factory.Endpoint.Address = new EndpointAddress(address);
                this.roomService = factory.CreateChannel();
                this.roomService.Connect(currentUser);
            }
        }

        public void Disconnect()
        {
            this.roomService.Disconnect(currentUser);
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
            roomService.IsWriting(currentUser);
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
            instanceContext.Close();
        }
        #endregion
    }
}
