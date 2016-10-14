using StreamChatApp.Communication.BLLInterfaces;
using StreamChatApp.Communication.CallBackInterface;
using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.BLL.Logic
{
    public class Configuration : IConfiguration
    {
        public string RoomIpAddress
        {
            get; set;
        }
    }
}
