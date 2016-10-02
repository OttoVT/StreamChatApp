using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using StreamChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.App_Start
{
    public static class DependencyConfiguration
    {
        private readonly static IUnityContainer container = new UnityContainer();

        public static IUnityContainer Container { get { return container; } }

        public static void ConfigureDependencies()
        {
            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
            #region RegisterTypes

            #region Model

            #endregion

            #region ViewModel
            container.RegisterType<MainViewModel>();
            container.RegisterType<ChatViewModel>();
            #endregion
            #endregion
        }


    }
}
