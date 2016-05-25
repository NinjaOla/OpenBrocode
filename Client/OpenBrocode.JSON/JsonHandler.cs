using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode.JSON
{
    public class JsonHandler
    {
        private SettingsClass settings = null; 

        public JsonHandler()
        {
            settings = new SettingsClass();
            this.settings.Filepath = "SettingsJson.json";
        }

        private void objectFromJSON()
        {
            // strings the json file
            string jsonString = File.ReadAllText(settings.Filepath);
            //Converts it to an object from Settings class

            this.settings = JsonConvert.DeserializeObject<SettingsClass>(jsonString);
            //SettingsClass sc1 = JsonConvert.DeserializeObject<SettingsClass>(jsonString);

        }

        public SettingsClass getSettings()
        {

            objectFromJSON();
            if (this.settings == null)
                throw new Exception("The settings class is null");

            return this.settings; 
        }



        public void objectToJson(string pFaceUN, string pFacePW, bool pFaceCHK, string pMailUN,
            string pMailPW, bool pMailCHK, string pTwitUN, string pTwitPW, bool pTwitCHK)
        {

            this.settings.FaceUN = pFaceUN;
            this.settings.FacePW = pFacePW;
            this.settings.FaceCHK = pFaceCHK;
            this.settings.MailUN = pMailUN;
            this.settings.MailPW = pMailPW;
            this.settings.mailCHK = pMailCHK;
            this.settings.TwitUN = pTwitUN;
            this.settings.TwitPW = pTwitPW;
            this.settings.TwitCHK = pTwitCHK;


            string jsonToFile = JsonConvert.SerializeObject(settings);
            File.WriteAllText(settings.Filepath, jsonToFile);
           
            
        }

        
    }
}
