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
        public ChatModel(IRoomClient roomClient)
        {
            this.roomClient = roomClient;
        }

        public ICallBackEvents CallBackObserver { get { return this.roomClient.CallBackObserver; }  }
    }
}
