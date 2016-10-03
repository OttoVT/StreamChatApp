using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using StreamChatApp.Communication.BLL.Logic;
using StreamChatApp.Communication.BLLInterface;
using StreamChatApp.Communication.Server;
using StreamChatApp.Communication.ServerInterface;
using StreamChatApp.Hosting;
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

        //Call once to configure app
        public static void ConfigureDependencies()
        {
            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
            #region RegisterTypes

            #region
            #endregion

            #region Communication
            container.RegisterType<IRoomContext, RoomContext>();
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<IRoomHost, RoomHost>();
            #endregion

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
