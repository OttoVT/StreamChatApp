using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ChatViewModel ChatViewModel { get; private set; }
        public MainViewModel(ChatViewModel chatViewModel)
        {
            ChatViewModel = chatViewModel;
        }
    }
}
