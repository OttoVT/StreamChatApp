using StreamChatApp.Model;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.ServerInterface
{

    [ServiceContract(SessionMode = SessionMode.Allowed, CallbackContract = typeof(IRoomCallBack))]
    public interface IRoomService
    {
        [OperationContract(IsInitiating = true)]
        bool Connect(Client client);

        [OperationContract(IsOneWay = true)]
        void Say(Message msg);

        [OperationContract(IsOneWay = true)]
        void Whisper(Message msg, Client receiver);

        [OperationContract(IsOneWay = true)]
        void IsWriting(Client client);

        [OperationContract(IsOneWay = false)]
        bool SendFile(FileMessage fileMsg, Client receiver);

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Disconnect(Client client);
    }
}
