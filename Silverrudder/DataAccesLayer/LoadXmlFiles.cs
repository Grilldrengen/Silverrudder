using System;
using System.Collections.Generic;
using Domain;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace DataAccesLayer
{
    class LoadXmlFiles
    {
        public static List<Participant> LoadParticipantListFromXmlFile()
        {
            string participantFile = "participants.xml";

            if (string.IsNullOrEmpty(participantFile)) { return default(List<Participant>); }

            List<Participant> objectOut = default(List<Participant>);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(participantFile);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<Participant>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (List<Participant>)serializer.Deserialize(reader);
                    reader.Close();
                }
                read.Close();
            }
            return objectOut;
        }


        public static List<Participant> LoadCategoryListFromXmlFile()
        {
            string categoryFile = "categories.xml";

            if (string.IsNullOrEmpty(categoryFile)) { return default(List<Participant>); }

            List<Participant> objectOut = default(List<Participant>);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(categoryFile);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<Participant>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (List<Participant>)serializer.Deserialize(reader);
                    reader.Close();
                }
                read.Close();
            }
            return objectOut;
        }
    }
}
