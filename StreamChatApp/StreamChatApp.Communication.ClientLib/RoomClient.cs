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
    public class RoomClient : IDisposable
    {
        protected InstanceContext instanceContext;
        protected IRoomService roomService;
        
        public RoomClient()
        {
            CallBackObserver = new CallBackObserver();
            instanceContext = new InstanceContext(new CallBackHandler(CallBackObserver));
        }
        public CallBackObserver CallBackObserver { get; protected set; }

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

        public void Dispose()
        {
            //TODO: unregister all;
        }
    }

    public class CallBackObserver : IRoomCallBack
    {
        #region delegate
        public delegate void RefreshClientsEventHandler(object sender, List<Client> clients);
        public delegate void ReceiveEventHandler(object sender, Message msg);
        public delegate void ReceiveWhisperEventHandler(object sender, Message msg, Client receiver);
        public delegate void IsWritingCallbackEventHandler(object sender, Client receiver);
        public delegate void ReceiveFileEventHandler(object sender, FileMessage fileMsg, Client receiver);
        public delegate void UserJoinEventHandler(object sender, Client receiver);
        public delegate void UserLeaveEventHandler(object sender, Client receiver);
        #endregion

        #region events
        // Declare the event.
        public event RefreshClientsEventHandler RefreshClientsEvent;
        public event ReceiveEventHandler ReceiveEvent;
        public event ReceiveWhisperEventHandler ReceiveWhisperEvent;
        public event IsWritingCallbackEventHandler IsWritingCallbackEvent;
        public event ReceiveFileEventHandler ReceiveFileEvent;
        public event UserJoinEventHandler UserJoinEvent;
        public event UserLeaveEventHandler UserLeaveEvent;
        #endregion

        public void RefreshClients(List<Client> clients)
        {
            if (RefreshClientsEvent != null)
                RefreshClientsEvent.Invoke(this, clients);
        }

        public void Receive(Message msg)
        {
            if (ReceiveEvent != null)
                ReceiveEvent.Invoke(this, msg);
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            if (ReceiveWhisperEvent != null)
                ReceiveWhisperEvent.Invoke(this, msg, receiver);
        }

        public void IsWritingCallback(Client client)
        {
            if (IsWritingCallbackEvent != null)
                IsWritingCallbackEvent.Invoke(this, client);
        }

        public void ReceiveFile(FileMessage fileMsg, Client receiver)
        {
            if(ReceiveFileEvent != null)
                ReceiveFileEvent.Invoke(this, fileMsg, receiver);
        }

        public void UserJoin(Client client)
        {
            if (UserJoinEvent != null)
                UserJoinEvent.Invoke(this, client);
        }

        public void UserLeave(Client client)
        {
            if (UserLeaveEvent != null)
                UserLeaveEvent.Invoke(this, client);
        }
    }

    internal class CallBackHandler : IRoomCallBack
    {
        protected CallBackObserver observer;
        public CallBackHandler(CallBackObserver observer)
        {
            this.observer = observer;
        }
        public void IsWritingCallback(Client client)
        {
            observer.IsWritingCallback(client);
        }

        public void Receive(Message msg)
        {
            observer.Receive(msg);
        }

        public void ReceiveFile(FileMessage fileMsg, Client receiver)
        {
            observer.ReceiveFile(fileMsg, receiver);
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            observer.ReceiveWhisper(msg, receiver);
        }

        public void RefreshClients(List<Client> clients)
        {
            observer.RefreshClients(clients);
        }

        public void UserJoin(Client client)
        {
            observer.UserJoin(client);
        }

        public void UserLeave(Client client)
        {
            observer.UserLeave(client);
        }
    }
}
