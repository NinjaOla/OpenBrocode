using com.OB.Facebook.Interfaces;
using com.OB.Facebook.Settings;
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

        SettingsTemplate template; 

        public List<Type> types = new List<Type>
        {
            typeof(IFacebookVersionInit)
        };

        public List<Object> values = new List<Object>();

        private string version = null; 

        public VersionManager(string version = "2.7")
        {
            template = com.OB.Facebook.Settings.FacebookSettings.load();

            this.version = version; 

            this.load(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
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
                        if(type != typeof(IFacebookVersionInit) && type.IsAssignableFrom(typeof(IFacebookVersionInit)))
                        {
                            IFacebookVersionInit versionObject = (IFacebookVersionInit)Activator.CreateInstance(type); 

                            if(versionObject != null)
                            {
                               if (versionObject.getVersion().Contains(this.version))
                               {
                                   loadFiles(types); 
                                   return; 
                               }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }

        }

        private void loadFiles(Type[] types)
        {
            foreach(Type type in types) 
            {

                if(this.isInInterfaceList(type))
                {
                    this.values.Add(type);
                }
            }


            if(!com.OB.Facebook.Settings.FacebookSettings.load().IgnoreMissingFilesOnVersion)
            {
                if(types.Count() != values.Count())
                {
                    throw new Exception("Missing implementation of some files. If you want to continue, set the IgnoreMissingFilesOnVersion to true in the settings file"); 
                }
            }

        }

        private bool isInInterfaceList(Type type)
        {
            foreach (Type t in this.types)
            {
                if (type != t && type.IsAssignableFrom(t))
                    return true; 
            }

            return false; 
        }
    }
}
