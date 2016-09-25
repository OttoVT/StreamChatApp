﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Model
{
    [DataContract]
    public class OperationResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
