using Microsoft.Practices.Unity;
using StreamChatApp.App_Start;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Utils
{
    public class ViewModelLocator : DynamicObject
    {
        public IViewModelResolver Resolver { get; set; }
        public object this[string viewModelName]
        {
            get
            {
                return Resolver?.Resolve(viewModelName);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
    }
}
