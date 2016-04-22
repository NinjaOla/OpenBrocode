using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter();
            twitter.loginEventHandler += new EventHandler(loginEvent);
            twitter.authenticateApp();
            System.Console.ReadLine();
        }

        public static void loginEvent(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Login works");
        }
    }
}
