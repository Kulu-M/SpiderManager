using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using SpiderManager;
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
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._vm));
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
                App._vm = JsonConvert.DeserializeObject<SpiderVM>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json")));
                if (App._vm == null)
                {
                    App._vm = new SpiderVM();
                }
            }
            catch (Exception e)
            {
                //TODO ?
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._vm));
                Console.WriteLine(e);
            }
            
        }
    }

    
}
