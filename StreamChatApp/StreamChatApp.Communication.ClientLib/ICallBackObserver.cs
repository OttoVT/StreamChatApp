using StreamChatApp.Communication.BLLInterfaces;
using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Model.Contracts;
using System.Collections.Generic;

namespace StreamChatApp.Communication.ClientLib
{ 

    public interface ICallBackObserver : ICallBackEvents, IRoomCallBack
    {
    }
}