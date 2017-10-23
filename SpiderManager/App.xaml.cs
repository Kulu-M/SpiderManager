using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ParentalMonitor.Classes;
using SpiderManager.Classes;

namespace SpiderManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Safe> _data;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SafeLoad.LoadFromJson();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SafeLoad.SaveToJson();
        }
    }
}
