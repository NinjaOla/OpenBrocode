using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json; 

namespace com.OB.Facebook.Settings
{
    public class FacebookSettings
    {

        private static string settingName = "settings.txt";

        private static SettingsTemplate settingTemple; 

        private static string SettingPath
        {
            get 
            {
                return dir + "\\" + settingName; 
            }
            set 
            {
                settingName = value; 
            }
        }

        private static string dir
        {
            get
            {
                return Directory.GetCurrentDirectory(); 
            }
        }

        public FacebookSettings()
        {

        }

        /// <summary>
        /// Used to load the settings file. 
        /// Populates on if it does not exists. 
        /// </summary>
        /// <returns></returns>
        public static SettingsTemplate load()
        {
            if (File.Exists(SettingPath))
            {
                settingTemple = JsonConvert.DeserializeObject<SettingsTemplate>(File.ReadAllText(SettingPath));
            }
            else
                createSettings(); 

            return settingTemple;
        }

        public static void createSettings(string settingsName = null, SettingsTemplate template = null)
        {
            if (!String.IsNullOrEmpty(settingsName))
                SettingPath = settingName;


            settingTemple = new SettingsTemplate(); 

            string value = JsonConvert.SerializeObject(settingTemple); 

            System.IO.File.WriteAllText(SettingPath, value);
        }



    }
}
