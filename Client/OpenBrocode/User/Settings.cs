using OpenBrocode.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode.User
{
    internal class Settings
    {
        public JsonHandler handler = new JsonHandler();

        public SettingsClass settings; 

        public Settings()
        {
            this.load();
        }

        public  void load()
        {
            this.settings = handler.getSettings();
        }

        //TODO: Update this to check if an value is null ... 
        public void writeFile()
        {
            handler.write(this.settings); 
        }
    }
}
