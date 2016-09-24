using StreamChatApp.App_Start;
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
        public void StartUp()
        {
            DependencyConfiguration.ConfigureDependencies();
        }
    }
}
