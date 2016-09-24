using StreamChatApp.Communication.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.Server
{
    public class Room
    {
        private List<IRoomMember> roomMembers;

        public Room()
        {
            roomMembers = new List<IRoomMember>();
        }
    }
}
