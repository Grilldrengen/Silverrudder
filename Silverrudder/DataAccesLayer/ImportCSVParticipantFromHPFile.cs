using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccesLayer
{
    public class ImportCSVParticipantFromHPFile
    {
        public List<Participant> ReadCSVFile(string filePath)   //Returnerer en liste med hver linje i CSV-filen som en streng 
        {
            List<string> listOfStrings = new List<string>();
            List<Participant> participantList = new List<Participant>();

            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\n');
                    listOfStrings.AddRange(values);
                }
            }
            participantList = AddValuesFromCSVFile(listOfStrings);
            return participantList;
        }

        private List<Participant> AddValuesFromCSVFile(List<string> listOfStrings)
        {
            List<Participant> participantsList = new List<Participant>();

            foreach (string line in listOfStrings)
            {
                Participant participant = new Participant();
                Boat boat = new Boat();

                string[] values = line.Split(';');

                participant.Name = values[0];
                participant.Country = values[1].Substring(0, 3).ToUpper();
                participant.CategoryAssignedByParticipant = values[4];

                boat.Model = values[2];
                boat.Name = values[3];
                boat.SailNumber = values[5];

                participant.Boat = boat;

                participantsList.Add(participant);
            }

            return participantsList;
        }
    }
}
