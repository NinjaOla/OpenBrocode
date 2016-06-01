using com.OB.Facebook.Functionality.Exceptions;
using com.OB.Facebook.Parameters.Premissions;
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

        private Dictionary<String, Boolean> premissions = new Dictionary<String, Boolean>(); 

        /// <summary>
        /// Look at Paramters.Premssions.PremissionList where there is a dictionary of all rights that is valid. 
        /// If you want the premissions set the value to true. 
        /// </summary>
        public Dictionary<String, Boolean> Premissions
        {
            get
            {
                return premissions; 
            }
            set
            {
                if (value == null)
                    throw new Exception("Scope cannot be null"); 

                foreach(KeyValuePair<String, Boolean> entry in value)
                {
                    if (entry.Value == true && PremissionList.inPremissionList(entry.Key))
                        this.premissions.Add(entry.Key, entry.Value);

                    if (this.premissions.Count == 0)
                        throw new FacebookException("There have to be some premissions set to true"); 
                }
            }
        }

        public Scope()
        {

        }

        public string getRights()
        {

            string temp = ""; 

            foreach(KeyValuePair<String, Boolean> entry in this.premissions)
            {
                temp += entry.Key + ","; 
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
