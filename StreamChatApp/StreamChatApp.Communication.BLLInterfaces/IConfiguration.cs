using StreamChatApp.Model.Contracts;

namespace StreamChatApp.Communication.BLLInterfaces
{
    public interface IConfiguration
    {
        string RoomIpAddress { get; set; }
    }
}