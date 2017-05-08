using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Collections.ObjectModel;

namespace DataAccesLayer
{
    public class ImportCSVParticipantFromHPFile
    {
        public ObservableCollection<Participant> ReadCSVFile(string filePath)   //Returnerer en liste med hver linje i CSV-filen som en streng 
        {
            List<string> listOfStrings = new List<string>();
            ObservableCollection<Participant> participantList = new ObservableCollection<Participant>();

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

        private ObservableCollection<Participant> AddValuesFromCSVFile(List<string> listOfStrings)
        {
            ObservableCollection<Participant> participantsList = new ObservableCollection<Participant>();

            foreach (string line in listOfStrings)
            {
                Participant participant = new Participant();
                Boat boat = new Boat();

                string[] values = line.Split(';');

                participant.Name = values[0];
                participant.Country = values[1];
                participant.Category = values[4];

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
