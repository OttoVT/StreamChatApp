using StreamChatApp.Communication.ServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StreamChatApp.Model.Contracts;
using StreamChatApp.ViewModel;

namespace StreamChatApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window, IRoomCallBack
    {
        public MainView()
        {
            InitializeComponent();
        }

        #region IRoomCallBack
        public void IsWritingCallback(Client client)
        {
            throw new NotImplementedException();
        }

        public void Receive(Message msg)
        {
            throw new NotImplementedException();
        }

        public void ReceiverFile(FileMessage fileMsg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void ReceiveWhisper(Message msg, Client receiver)
        {
            throw new NotImplementedException();
        }

        public void RefreshClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }

        public void UserJoin(Client client)
        {
            throw new NotImplementedException();
        }

        public void UserLeave(Client client)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
