using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Parameters.Premissions
{
    class PublicProfile
    {
        private static readonly string public_profile = "public_profile";

        public string Id { get; set; }

        public string Name { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Age_Range { get; set; }

        public string Link { get; set; }

        public string Gender { get; set; }

        public string Local { get; set; }

        public string Picture { get; set; }

        public string Timezone { get; set; }

        public string Updated_Time { get; set; }

        public string Verified { get; set; }

        private PublicProfile()
        {

        }

        public PublicProfile(PublicProfile publicProfile)
        {
            if (publicProfile == null)
                throw new NullReferenceException("Public profile cannot be null");

            this.Id = publicProfile.Id;

            this.Name = publicProfile.Name;

            this.First_Name = publicProfile.First_Name;

            this.Last_Name = publicProfile.Last_Name;

            this.Age_Range = publicProfile.Age_Range;

            this.Link = publicProfile.Link;

            this.Gender = publicProfile.Gender;

            this.Local = publicProfile.Local;

            this.Picture = publicProfile.Picture;

            this.Timezone = publicProfile.Timezone;

            this.Updated_Time = publicProfile.Updated_Time;

            this.Verified = publicProfile.Verified; 
        }


        public static string ToString()
        {
            return public_profile; 
        }

    }
}
