using StreamChatApp.Communication.ServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using System.ServiceModel;


namespace StreamChatApp.Communication.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class RoomService : IRoomService
    {
        Dictionary<Client, IRoomCallBack> clients = new Dictionary<Client, IRoomCallBack>();

        List<Client> clientList = new List<Client>();

        public IRoomCallBack CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IRoomCallBack>();

            }
        }
        public bool Connect(Model.Contracts.Client client)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(Model.Contracts.Client client)
        {
            throw new NotImplementedException();
        }

        public void IsWriting(Model.Contracts.Client client)
        {
            throw new NotImplementedException();
        }

        public void Say(Message msg)
        {
            throw new NotImplementedException();
        }

        public bool SendFile(FileMessage fileMsg, Model.Contracts.Client receiver)
        {
            throw new NotImplementedException();
        }

        public void Whisper(Message msg, Model.Contracts.Client receiver)
        {
            throw new NotImplementedException();
        }
    }
}
