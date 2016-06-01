using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OpenBrocode.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SettingsClass
    {

        //Why a class for this? Very easy to work with json.


        //The sections we have now/soon
        //The checkers are to check if the user have them enabled. If not they should not show up on the side menu (LeftSideBarUC)

        public SettingsClass()
        {

        }

        public SettingsClass(SettingsClass c)
        {
            this.FaceUN = c.FaceUN;

            this.FacePW = c.FacePW;

            this.FaceCHK = c.FaceCHK;

            this.MailUN = c.MailUN;

            this.MailPW = c.MailPW;

            this.mailCHK = c.mailCHK;

            this.TwitCHK = c.TwitCHK;

            this.Filepath = c.Filepath; 
        }


        //facebook
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string FaceUN { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string FacePW { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool FaceCHK { get; set; }


        //mail
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string MailUN { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string MailPW { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool mailCHK { get; set; }

        //twitter
        [JsonProperty]
        public bool TwitCHK { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string TwitterUserToken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string TwitterUserSecretToken { get; set; }

        //user
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Filepath  { get; set; }
        

        }



}
