using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Parameters
{
    public class Scope
    {
        public readonly string identifier = Parameter.Scope;

        private ArrayList list = new ArrayList();

        public Boolean PublicProfile = false;

        public Boolean All = false; 

        public Scope()
        {

        }

        public Scope(Scope scope)
        {
            if (scope == null)
                throw new NullReferenceException("Scope cannot be null");

            this.All = scope.All; 

            this.PublicProfile = scope.PublicProfile; 

        }

        public string getRights()
        {

            string temp = ""; 

            if(this.All)
            {
                temp += com.OB.Facebook.Parameters.Premissions.PublicProfile.ToString() + ",";
            }
            else
            {

                if(this.PublicProfile)
                {
                    temp += com.OB.Facebook.Parameters.Premissions.PublicProfile.ToString() + ","; 
                }
            }

            temp = temp.TrimEnd(',');


            if (String.IsNullOrEmpty(temp))
                return null;
            else
                return temp; 

        }


        public override string ToString()
        {
            return this.identifier; 
        }



    }
}
