﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccesLayer;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class ParticipantRepository
    {
        ImportCSVParticipantFromHPFile importCSVParticipantFromHPFile = new ImportCSVParticipantFromHPFile();
        SortParticipantAssignedCategori sortParticipantAssignedCategori = new SortParticipantAssignedCategori();

        public void Create(Participant Participant)
        {
            Participant part = ParticipantList.Instance.participantList.FirstOrDefault(p => p.ParticipantNumber == Participant.ParticipantNumber);
            if (part == null)
                ParticipantList.Instance.participantList.Add(Participant);
        }

        public void Delete(Participant Participant)
        {
            ParticipantList.Instance.participantList.Remove(Participant);
        }



        public ObservableCollection<Participant> GetAll()
        {
            return ParticipantList.Instance.participantList;
        }

        private bool TryParseStringToInt(string value)
        {
            int participantNumber;
            bool res = int.TryParse(value, out participantNumber);

            if (res == true)
                return true;

            else return false;
        }

        public ObservableCollection<Participant> GetParticipantsFromCSVSilverrudderHPFile(string path)
        {
            ObservableCollection<Participant> participantFromCSVFile = new ObservableCollection<Participant>();

            participantFromCSVFile = importCSVParticipantFromHPFile.ReadCSVFile(path);
            return participantFromCSVFile;
        }

        public void AssignParticipantsToParticipantAssignedCategories()
        {
            sortParticipantAssignedCategori.StartSorting();
        }


    }
}
