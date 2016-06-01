using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Interfaces
{
    public interface IFacebookVersionInit
    {

        /// <summary>
        /// When implementing this there is expected to be a version, this is the format in : '2.7'.
        /// This is expected to be the facebook api version the operations operates against. 
        /// </summary>
        /// <returns></returns>
        string getVersion(); 
    }
}
