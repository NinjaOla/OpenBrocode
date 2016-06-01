using com.OB.Facebook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Version._2_7
{
    internal class Init : IFacebookVersionInit 
    {
       public Init()
       {
           
       }

       public string getVersion()
       {
           return "2.7"; 
       }
    }
}
