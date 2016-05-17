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

        private static string settingsName = "settings.txt";

        private static SettingsTemplate template = null; 

        private static string dir
        {
            get
            {
                return Directory.GetCurrentDirectory(); 
            }
        }

        /// <summary>
        /// Used to load the settings file. 
        /// Populates on if it does not exists. 
        /// </summary>
        /// <returns></returns>
        public static SettingsTemplate loadSettings()
        {

            //SettingsTemplate template = new SettingsTemplate(); 

            if (Directory.Exists(dir + settingsName))
            {
                template = JsonConvert.DeserializeObject<SettingsTemplate>(File.ReadAllText(dir + settingsName));

            }
            else
                createSettings();


            return template; 

 
        }

        public static void createSettings(string settingsName = null, SettingsTemplate template = null)
        {
            if (String.IsNullOrEmpty(settingsName))
                settingsName = FacebookSettings.settingsName; 
            

        }


        public static SettingsTemplate getTemplateFromJsonString(string jsonContent)
        {
            List<SettingsTemplate> template = JsonConvert.DeserializeObject<List<SettingsTemplate>>(jsonContent, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Populate, 
                NullValueHandling = NullValueHandling.Include
            });

            if (template.Count > 1)
            {
                throw new Exception("Found more objects in the template than expected");
            }

            return template.First(); 

        }

    }
}
