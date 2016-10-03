namespace StreamChatApp.Hosting
{
    public interface IRoomHost
    {
        void StartRoom(int port);
        void StopRoom();
    }
}