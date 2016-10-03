using StreamChatApp.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Model
{
    public class HostModel
    {
        private IRoomHost roomHost;

        public HostModel(IRoomHost roomHost)
        {
            this.roomHost = roomHost;
        }

        public void Start()
        {
            roomHost.StartRoom(9897);
        }

        public void Stop()
        {
            roomHost.StopRoom();
        }
    }
}
