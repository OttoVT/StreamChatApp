﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Model.Contracts
{
    [DataContract]
    public class FileMessage
    {
        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public byte[] Data { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}