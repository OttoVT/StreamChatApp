using StreamChatApp.Model.Contracts;

namespace StreamChatApp.Communication.ClientLib
{
    public interface IUserContext
    {
        Client CurrentUser { get; set; }
    }
}