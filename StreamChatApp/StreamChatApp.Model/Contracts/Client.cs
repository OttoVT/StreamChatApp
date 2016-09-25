using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Model.Contracts
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public Guid ClientId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public string OpenKey { get; set; }
    }
}
