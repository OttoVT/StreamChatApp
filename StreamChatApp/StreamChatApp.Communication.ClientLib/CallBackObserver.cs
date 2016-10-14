using StreamChatApp.Communication.BLLInterfaces;
using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.ClientLib
{
    public class CallBackObserver : ICallBackObserver
    {
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
                RefreshClientsEvent.Invoke(clients);
        }

        public void Receive(Message msg)
        {
            if (ReceiveEvent != null)
                ReceiveEvent.Invoke(msg);
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            if (ReceiveWhisperEvent != null)
                ReceiveWhisperEvent.Invoke(msg, receiver);
        }

        public void IsWritingCallback(Client client)
        {
            if (IsWritingCallbackEvent != null)
                IsWritingCallbackEvent.Invoke(client);
        }

        public void ReceiveFile(FileMessage fileMsg, Client receiver)
        {
            if (ReceiveFileEvent != null)
                ReceiveFileEvent.Invoke(fileMsg, receiver);
        }

        public void UserJoin(Client client)
        {
            if (UserJoinEvent != null)
                UserJoinEvent.Invoke(client);
        }

        public void UserLeave(Client client)
        {
            if (UserLeaveEvent != null)
                UserLeaveEvent.Invoke(client);
        }

        public void Unsubscribe()
        {
            foreach (var d in IsWritingCallbackEvent?.GetInvocationList())
                IsWritingCallbackEvent -= (d as IsWritingCallbackEventHandler);

            foreach (var d in ReceiveEvent?.GetInvocationList())
                ReceiveEvent -= (d as ReceiveEventHandler);

            foreach (var d in RefreshClientsEvent?.GetInvocationList())
                RefreshClientsEvent -= (d as RefreshClientsEventHandler);

            foreach (var d in ReceiveWhisperEvent?.GetInvocationList())
                ReceiveWhisperEvent -= (d as ReceiveWhisperEventHandler);

            foreach (var d in ReceiveFileEvent?.GetInvocationList())
                ReceiveFileEvent -= (d as ReceiveFileEventHandler);

            foreach (var d in UserJoinEvent?.GetInvocationList())
                UserJoinEvent -= (d as UserJoinEventHandler);

            foreach (var d in UserLeaveEvent?.GetInvocationList())
                UserLeaveEvent -= (d as UserLeaveEventHandler);
        }
    }
}
