using StreamChatApp.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.ClientLib
{
    public class UserContext : IUserContext
    {
        protected Client currentUser;
        public Client CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                if (currentUser == null)
                {
                    currentUser = value;
                }
            }
        }
        public UserContext()
        {
        }
    }
}
