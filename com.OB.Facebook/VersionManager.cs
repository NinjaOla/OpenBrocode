using com.OB.Facebook.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook
{
    class VersionManager
    {
        


        public VersionManager()
        {

        }

        private void load()
        {
            string path = Directory.GetCurrentDirectory();
            string[] dlls = Directory.GetFiles(path, "*.dll"); 

            foreach(string dll in dlls)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(dll);
                    Type[] types = assembly.GetExportedTypes(); 

                    foreach(Type type in types)
                    {
                        if(type != typeof(IFacebookVersionInit))
                        {
                            IFacebookVersionInit version = (IFacebookVersionInit)Activator.CreateInstance(type); 

                            if(version != null)
                            {
                                
                            }
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }

        }

        private void loadFiles()
        {

        }
    }
}
