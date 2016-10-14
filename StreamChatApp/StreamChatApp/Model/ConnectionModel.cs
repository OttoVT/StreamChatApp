using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamChatApp.Model.Contracts;
using StreamChatApp.Communication.ClientLib;
using StreamChatApp.Communication.BLLInterfaces;

namespace StreamChatApp.Model
{
    public class ConnectionModel
    {
        private IConfiguration configuration;
        public ConnectionModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string RoomIpAddress
        {
            get
            {
                return configuration.RoomIpAddress;
            }
            set
            {
                configuration.RoomIpAddress = value;
            }
        }
    }
}
