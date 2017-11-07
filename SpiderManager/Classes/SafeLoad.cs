using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using SpiderManager;
using SpiderManager.Classes;
using SpiderManager.Properties;
using System.Collections.ObjectModel;
using SpiderManager.Model;

namespace ParentalMonitor.Classes
{
    public class SafeLoad
    {
        public static void SaveToJson()
        {
            try
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._spiderList));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void LoadFromJson()
        {

            try
            {
                App._spiderList = JsonConvert.DeserializeObject<ObservableCollection<Spider>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json")));
            }
            catch (Exception e)
            {
                //TODO ?
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._spiderList));
                Console.WriteLine(e);
            }
            
        }
    }

    
}
