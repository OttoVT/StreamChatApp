namespace StreamChatApp.Utils
{
    public interface IViewModelResolver
    {
        object Resolve(string viewModelNameName);
    }
}