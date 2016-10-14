using StreamChatApp.Commands;
using StreamChatApp.Model;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StreamChatApp.ViewModel
{
    public class ConnectionViewModel : ViewModelBase
    {
        protected ConnectionModel connectionModel;
        public ConnectionViewModel(ConnectionModel connectionModel)
        {
            this.connectionModel = connectionModel;

            ConnectToRoom = new DelegateCommand((x) =>
            {
                var window = x as Window;
                if (window != null)
                {
                    window.DialogResult = true;
                    CloseWindow(window);
                }
            }
            , null);
        }

        public DelegateCommand ConnectToRoom { get; set; }
        public string IpAddress
        {
            get
            {
                return connectionModel.RoomIpAddress;
            }
            set
            {
                connectionModel.RoomIpAddress = value;
                RaisePropertyChanged(nameof(IpAddress));
            }
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
