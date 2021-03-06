﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ParentalMonitor.Classes;
using System.Collections.ObjectModel;
using SpiderManager.Model;
using SpiderManager.Classes;

namespace SpiderManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SpiderVM _vm = new SpiderVM();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _vm.spiderList = new ObservableCollection<Spider>();
            SafeLoad.LoadFromJson();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            FeedingReminder.clearFeedingList();
            SafeLoad.SaveToJson();
        }
    }
}
