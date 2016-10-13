using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.ViewModel
{
    public class ChatViewModel : ViewModelBase
    {
        protected IRoomClient roomClient;
        public ChatViewModel(IRoomClient roomClient)
        {
            this.roomClient = roomClient;
        }
    }
}
