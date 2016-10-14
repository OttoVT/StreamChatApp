using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.BLLInterfaces
{
    public delegate void RefreshClientsEventHandler(List<Client> clients);
    public delegate void ReceiveEventHandler(Message msg);
    public delegate void ReceiveWhisperEventHandler(Message msg, Client receiver);
    public delegate void IsWritingCallbackEventHandler(Client receiver);
    public delegate void ReceiveFileEventHandler(FileMessage fileMsg, Client receiver);
    public delegate void UserJoinEventHandler(Client receiver);
    public delegate void UserLeaveEventHandler(Client receiver);

    public interface ICallBackEvents
    {
        event IsWritingCallbackEventHandler IsWritingCallbackEvent;
        event ReceiveEventHandler ReceiveEvent;
        event ReceiveFileEventHandler ReceiveFileEvent;
        event ReceiveWhisperEventHandler ReceiveWhisperEvent;
        event RefreshClientsEventHandler RefreshClientsEvent;
        event UserJoinEventHandler UserJoinEvent;
        event UserLeaveEventHandler UserLeaveEvent;

        void Unsubscribe();
    }
}
