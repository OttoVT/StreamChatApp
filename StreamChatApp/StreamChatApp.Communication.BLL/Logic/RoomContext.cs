
using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.BLL.Logic
{
    public class RoomContext
    {
        private Dictionary<Client, IRoomCallBack> clients = new Dictionary<Client, IRoomCallBack>();
        private List<Client> clientList = new List<Client>();
        private object syncObject = new object();
        public RoomContext()
        { }

        public bool Connect(BLLRequestContext<Client> context)
        {
            var callBack = context.CallBack;
            var client = context.Context;

            if (!clients.ContainsValue(context.CallBack))
            {
                lock (syncObject)
                {
                    clients[client] = context.CallBack;

                    foreach (Client key in clients.Keys)
                    {
                        IRoomCallBack callback = clients[key];
                        try
                        {
                            callback.RefreshClients(clientList);
                            callback.UserJoin(client);
                        }
                        catch
                        {
                            clients.Remove(key);
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        public void Disconnect(Model.Contracts.Client client)
        {
            var c = clients.Keys.FirstOrDefault(x => x.ClientId == client.ClientId);
            if (client.Name == c.Name)
            {
                lock (syncObject)
                {
                    this.clients.Remove(c);
                    this.clientList.Remove(c);
                    foreach (IRoomCallBack callback in clients.Values)
                    {
                        callback.RefreshClients(this.clientList);
                        callback.UserLeave(client);
                    }
                }
                return;
            }
        }

        public void IsWriting(Model.Contracts.Client client)
        {
            lock (syncObject)
            {
                foreach (var callback in clients.Values)
                {
                    callback.IsWritingCallback(client);
                }
            }
        }

        public void Say(Message msg)
        {
            lock (syncObject)
            {
                foreach (var callback in clients.Values)
                {
                    callback.Receive(msg);
                }
            }
        }

        public bool SendFile(FileMessage fileMsg, Model.Contracts.Client receiver)
        {
            var sender = clients.Keys.FirstOrDefault(x => x.ClientId == fileMsg.SenderId);
            var rec = clients.Keys.FirstOrDefault(x => x.ClientId == receiver.ClientId);

            Message msg = new Message();
            msg.SenderId = fileMsg.SenderId;
            msg.Sender = fileMsg.Sender;
            msg.Content = "I'M SENDING FILE.. " + fileMsg.FileName;

            var rcvrCallback = clients[sender];
            var sndrCallback = clients[sender];

            rcvrCallback?.ReceiveWhisper(msg, receiver);
            rcvrCallback?.ReceiverFile(fileMsg, receiver);
            sndrCallback?.ReceiveWhisper(msg, receiver);
            return true;
        }

        public void Whisper(Message msg, Model.Contracts.Client receiver)
        {
            var rec = clients.Keys.FirstOrDefault(x => x.ClientId == receiver.ClientId);
            var sender = clients.Keys.FirstOrDefault(x => x.ClientId == msg.SenderId);
            var callbackReciever = clients[rec];
            var callbackSender = clients[rec];
            callbackReciever.ReceiveWhisper(msg, rec);
            callbackSender.ReceiveWhisper(msg, rec);
        }
    }
}
