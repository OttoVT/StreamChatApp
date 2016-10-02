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
    public class ViewModelResolver : IViewModelResolver
    {
        public object Resolve(string viewModelNameName)
        {
            var foundType = GetType().Assembly.GetTypes().FirstOrDefault(type => type.Name == viewModelNameName);
            if (foundType == null)
                return null;

            return DependencyConfiguration.Container.Resolve(foundType);
        }
    }
}
