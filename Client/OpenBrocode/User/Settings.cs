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

        public Settings()
        {
            this.load();
        }

        public  SettingsClass load()
        {
            return handler.getSettings();
        }

        //TODO: Update this to check if an value is null ... 
        public  void writeFile(SettingsClass settings)
        {
            handler.write(settings); 
        }

    }
}
