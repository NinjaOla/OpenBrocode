using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OpenBrocode
{
    class SettingsClass
    {

        //Why a class for this? Very easy to work with json.


        //The sections we have now/soon
        //The checkers are to check if the user have them enabled. If not they should not show up on the side menu (LeftSideBarUC)

        //facebook
        public String FaceUN { get; set; }
        public String FacePW { get; set; }
        public Boolean FaceCHK { get; set; }

        //mail
        public String MailUN { get; set; }
        public String MailPW { get; set; }
        public Boolean mailCHK { get; set; }

        //twitter
        public String TwitUN { get; set; }
        public String TwitPW { get; set; }
        public Boolean TwitCHK { get; set; }


        //user
        public String Filepath { get; set; }


        //Checks if the settingsfile excist at the location
        public bool fileExcist()
        {
            Filepath = "C:/windows/settings.json";


            return (File.Exists(Filepath));

        }

    }
}
