
using StreamChatApp.Model.Contracts;

namespace StreamChatApp.Communication.BLLInterface
{
    public interface IRoomContext
    {
        bool Connect(BLLRequestContext<Client> context);
        void Disconnect(BLLRequestContext<Client> context);
        void IsWriting(BLLRequestContext<Client> context);
        void Say(BLLRequestContext<Message> request);
        bool SendFile(FileMessage fileMsg, Client receiver);
        void Whisper(Message msg, Client receiver);
    }
}