using StreamChatApp.Communication.CallBackInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using StreamChatApp.Communication.ServerInterface;

namespace StreamChatApp.Communication.ClientLib
{
    public class RoomClient
    {
        protected InstanceContext instanceContext;
        protected IRoomService roomService;
        public RoomClient()
        {
            instanceContext = new InstanceContext(new CallBackHandler());
        }

        public void Connect(string address)
        {
            NetTcpBinding tcpb = new NetTcpBinding();
            using (DuplexChannelFactory<IRoomService> factory
                = new DuplexChannelFactory<IRoomService>(instanceContext, tcpb))
            {
                factory.Endpoint.Address = new EndpointAddress(address);
                this.roomService = factory.CreateChannel();
            }
        }

        public void Disconnect()
        {
            this.roomService.Disconnect(null);
        }
    }

    public class CallBackHandler : IRoomCallBack
    {
        public void IsWritingCallback(Client client)
        {
            throw new NotImplementedException();
        }

        public void Receive(Message msg)
        {
            throw new NotImplementedException();
        }

        public void ReceiverFile(FileMessage fileMsg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void RefreshClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }

        public void UserJoin(Client client)
        {
            throw new NotImplementedException();
        }

        public void UserLeave(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
