using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Xml;
using System.Xml.Serialization;

namespace DataAccesLayer
{
    class SaveToXmlFiles
    {
        public static void CreateXMLFiles(string filePath)
        {
            if (!File.Exists("participants.xml"))
            {
                List<Participant> list = new List<Participant>();
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(list.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, list);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("participants.xml");
                    stream.Close();
                }
            }

            if (!File.Exists("categories.xml"))
            {
                List<Category> list = new List<Category>();
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(list.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, list);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("categories.xml");
                    stream.Close();
                }
            }
        }

        public static void SaveParticipantListToXmlFile(List<Participant> list, string file)
        {
            if (list == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, list);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(file);
                stream.Close();
            }
        }

        public static void SaveCategoryListToXmlFile(List<Category> list, string file)
        {
            if (list == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, list);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(file);
                stream.Close();
            }
        }
    }
}
