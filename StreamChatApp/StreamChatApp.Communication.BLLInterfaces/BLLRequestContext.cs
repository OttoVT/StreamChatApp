using StreamChatApp.Communication.CallBackInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Communication.BLLInterface
{
    public class BLLRequestContext
    {
        public object User { get; set; }

        public object Context { get; set; }

        public IRoomCallBack CallBack{ get; set; }
    }

    public class BLLRequestContext<T> : BLLRequestContext
    {
        public new T Context
        {
            get { return (T)base.Context; }
            set { base.Context = value; }
        }
    }
}
