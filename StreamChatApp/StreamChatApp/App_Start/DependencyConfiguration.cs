using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.App_Start
{
    public static class DependencyConfiguration
    {
        private static IUnityContainer container;
        public static void ConfigureDependencies()
        {
            container = new UnityContainer();
            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
            #region RegisterTypes

            #endregion
        }
    }
}
