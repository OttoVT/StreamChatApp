using StreamChatApp.Commands;
using StreamChatApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.ViewModel
{
    public class HostViewModel : ViewModelBase
    {
        public DelegateCommand StartHost { get; private set; }
        public DelegateCommand StopHost { get; private set; }

        private HostModel hostModel;
        public HostViewModel(HostModel hostModel)
        {
            this.hostModel = hostModel;
            StartHost = new DelegateCommand((a) => { this.hostModel.Start(); }, null);
            StartHost = new DelegateCommand((a) => { this.hostModel.Stop(); }, null);
        }
    }
}
