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
            if(!File.Exists(this.settings.Filepath))
            {
                objectToJson();
            }

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



        public void objectToJson(string pFaceUN = null, string pFacePW = null, bool pFaceCHK = false, string pMailUN = null,
            string pMailPW = null, bool pMailCHK = false, bool pTwitCHK = false)
        {

            this.settings.FaceUN = pFaceUN;
            this.settings.FacePW = pFacePW;
            this.settings.FaceCHK = pFaceCHK;
            this.settings.MailUN = pMailUN;
            this.settings.MailPW = pMailPW;
            this.settings.mailCHK = pMailCHK;
            this.settings.TwitCHK = pTwitCHK;


            string jsonToFile = JsonConvert.SerializeObject(settings);

            this.writetoFile(settings); 
            //File.WriteAllText(settings.Filepath, jsonToFile);
        }

        public void write(SettingsClass settings)
        {
            this.writetoFile(settings); 
        }


        /// <summary>
        /// Creates a new file with the info proviede from the settings object. 
        /// </summary>
        /// <param name="settings"></param>
        private void writetoFile(SettingsClass settings)
        {

            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,


            };
            
            if(File.Exists(settings.Filepath))
            {
                File.Delete(settings.Filepath);
            }

            FileStream fs = new FileStream(settings.Filepath, FileMode.CreateNew);

            fs.Position = fs.Length;

            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter js = new JsonTextWriter(sw))
            {
                try
                {
                    serializer.Serialize(js, settings);
                }
                catch (Exception e) 
                {
                    throw new Exception("Problem writing to the file", e); 
                }
            }
        }

        
    }
}
