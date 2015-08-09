// AppConfig.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    [Serializable]
    public sealed class AppConfig : ISerializable
    {
        private static readonly string sr_ConfigFile = "config.cfg";
        private static readonly object sr_CreationLockContext = new object();
        private static AppConfig s_Instance;

        public static AppConfig Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_CreationLockContext)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = AppConfig.LoadFromFile();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public string LastAccessToken { get; set; }

        public bool AutoConnect { get; set; }

        public Point LastWindowLocation { get; set; }

        public Size LastWindowSize { get; set; }

        private AppConfig()
        {
            LastAccessToken = string.Empty;
            AutoConnect = true;
            LastWindowSize = new Size(554, 269);
            LastWindowLocation = new Point(0, 0);
        }

        private static AppConfig LoadFromFile()
        {
            AppConfig appConfig = null;

            using (FileStream fileStream = new FileStream(sr_ConfigFile, FileMode.OpenOrCreate))
            {
                try
                {
                    fileStream.Flush();
                    XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                    appConfig = serializer.Deserialize(fileStream) as AppConfig;
                }
                catch (Exception e)
                {
                    appConfig = new AppConfig();
                }
            }

            return appConfig;
        }

        public static void SaveToFile()
        {
            using (FileStream fileStream = new FileStream(sr_ConfigFile, FileMode.Create))
            {
                fileStream.Flush();
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                serializer.Serialize(fileStream, Instance);
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(AppConfigHelper)); 
        }

        [Serializable]
        private class AppConfigHelper : IObjectReference
        {
            public object GetRealObject(StreamingContext context)
            {
                return new AppConfig();
            }
        }
    }
}
