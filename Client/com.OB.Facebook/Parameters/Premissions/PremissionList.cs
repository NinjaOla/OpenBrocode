using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Parameters.Premissions
{
    class PremissionList
    {
        public static Dictionary<String, Boolean> premissions = new Dictionary<String, Boolean>()
        {
            {"public_profile", false}, 
            {"user_friends", false}, 
            {"email", false}, 
            {"user_about_me", false}, 
            {"user_actions.books", false}, 
            {"user_actions.fitness", false}, 
            {"user_actions.music", false}, 
            {"user_actions.news", false},
            {"user_actions.video", false}, 
            {"user_actions:{0}", false}, 
            {"user_education_history", false}, 
            {"user_events", false}, 
            {"user_hometown", false}, 
            {"user_likes", false}, 
            {"user_location", false}, 
            {"user_managed_groups", false}, 
            {"user_photos", false}, 
            {"user_posts", false}, 
            {"user_realationships", false}, 
            {"user_realationship_details", false}, 
            {"user_religion_politics", false}, 
            {"user_tagged_places", false}, 
            {"user_videos", false}, 
            {"user_website", false}, 
            {"user_work_history", false}, 
            {"read_custom_friendlists", false}, 
            {"read_insights", false}, 
            {"read_audience_network_insights", false}, 
            {"read_page_mailboxes", false}, 
            {"manage_pages", false}, 
            {"publish_pages", false}, 
            {"publish_actions", false}, 
            {"rsvp_event", false}, 
            {"pages_show_list", false}, 
            {"pages_manage_cta", false}, 
            {"pages_manage_instant_articles", false},
            {"ads_read", false}, 
            {"ads_management", false}, 
            {"pages_messaging", false}, 
            {"pages_messaging_phone_number", false}
        }; 

        /// <summary>
        /// Gives the dicitionary with all the rights, use with caution. 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, Boolean> getAllRigts()
        {
            Dictionary<String, Boolean> temp = new Dictionary<String, Boolean>(); 

            foreach(KeyValuePair<String, Boolean> entry in premissions)
            {
                temp[entry.Key] = true; 
            }

            return temp; 
        }

        public static Boolean inPremissionList(String value)
        {
            if (value.Contains("user_actions"))
            {
                if (value.Contains("{0}"))
                    return false;
                else 
                    return true; 
            }
            else
            {
                if (premissions.ContainsKey(value))
                    return true; 
            }

            return false; 
        }
    }
}
