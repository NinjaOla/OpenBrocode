using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode
{
    class SettingsClass
    {


        //The sections we have now/soon
        //The checkers are to check if the user have them enabled. If not they should not show up on the side menu (LeftSideBarUC)

        //facebook
        public String faceUN { get; set; }
        public String facePW { get; set; }
        public Boolean faceCHK;

        //mail
        public String mailUN { get; set; }
        public String mailPW { get; set; }
        public Boolean mailCHK;

        //twitter
        public String twitUN { get; set; }
        public String twitPW { get; set; }
        public Boolean twitCHK { get; set; }

        

    }
}
