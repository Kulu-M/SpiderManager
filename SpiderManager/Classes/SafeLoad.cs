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

namespace ParentalMonitor.Classes
{
    public class SafeLoad
    {
        public static void SaveToJson()
        {
            try
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._data));
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
               //App._data = JsonConvert.DeserializeObject<Safe>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"))) ?? new Safe();
            }
            catch (Exception e)
            {
                //App._data = new Safe();
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._data));
                Console.WriteLine(e);
            }
            
        }
    }

    
}
