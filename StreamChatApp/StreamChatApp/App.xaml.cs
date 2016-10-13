using StreamChatApp.App_Start;
using StreamChatApp.View;
using StreamChatApp.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StreamChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DependencyConfiguration.ConfigureDependencies();
            base.OnStartup(e);
        }
        public void StartUp()
        {
        }
    }
}
