using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Los.Core;

namespace LoSAdmin
{
    public class Settings
    {
        public DatabaseSettings DatabaseConnection = new DatabaseSettings();

        public void Save()
        {
            var setting = Application.ExecutablePath + ".settings";

            FileStream file = new FileStream(setting, FileMode.Create);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                serializer.Serialize(file, this);
            }
            finally
            {
                file.Close();
            }
        }

        static public Settings Load()
        {
            var setting = Application.ExecutablePath + ".settings";
            object obj = null;
            FileStream file = new FileStream(setting, FileMode.Open);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                obj = serializer.Deserialize(file);
            }
            catch
            {
                obj = new Settings();
            }
            finally
            {
                file.Close();
            }

            return (Settings)obj;
        }


        static private Settings current = null;

        static internal Settings Current
        {
            get
            {
                if (current == null)
                {
                    current = Settings.Load();
                }
                return current;
            }        
        }
        
    }

}
