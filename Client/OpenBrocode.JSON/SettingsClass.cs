using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OpenBrocode.JSON
{
    public class SettingsClass
    {

        //Why a class for this? Very easy to work with json.


        //The sections we have now/soon
        //The checkers are to check if the user have them enabled. If not they should not show up on the side menu (LeftSideBarUC)

        //facebook
        public string FaceUN { get; set; }
        public string FacePW { get; set; }
        public bool FaceCHK { get; set; }


        //mail
        public string MailUN { get; set; }
        public string MailPW { get; set; }
        public bool mailCHK { get; set; }

        //twitter
        public bool TwitCHK { get; set; }


        //user
        public string Filepath  { get; set; }
        

        }



}
