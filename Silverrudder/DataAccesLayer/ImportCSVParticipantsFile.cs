﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BusinessLayer;

namespace DataAccesLayer
{
    public class ImportCSVParticipantsFile
    {
        ParticipantRepository participantRepository = new ParticipantRepository();

        public void ReadCSVFile(string filePath)   //Returnerer en liste med hver linje i CSV-filen som en streng 
        {
            List<string> listOfStrings = new List<string>();

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
            AddValuesFromCSVFile(listOfStrings);
        }

        private void AddValuesFromCSVFile(List<string> listOfStrings)
        {
            foreach (string line in listOfStrings)
            {
                Participant participant = new Participant();
                Boat boat = new Boat();

                string[] values = line.Split(';');

                participant.Name = values[0];
                participant.Country = values[1];

                boat.Model = values[2];
                boat.Name = values[3];
                boat.CategoryAssignedByParticipant = values[4];
                boat.SailNumber = values[5];

                participant.Boat = boat;

                participantRepository.Create(participant);
            }
        }
    }
}