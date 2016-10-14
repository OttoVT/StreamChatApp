using StreamChatApp.Model.Contracts;

namespace StreamChatApp.Communication.BLLInterfaces
{
    public interface IRoomClient
    {
        ICallBackEvents CallBackObserver { get; }

        void Connect(string address);
        void Disconnect();
        void IsWriting();
        void Say(Message msg);
        bool SendFile(FileMessage fileMsg, Client receiver);
        void SetCurrentUser(Client client);
        void Whisper(Message msg, Client receiver);
    }
}