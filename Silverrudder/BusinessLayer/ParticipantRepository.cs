using System;
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

        public void Change(Participant participant)
        {
            participant = ParticipantList.Instance.participantList.FirstOrDefault(p => p.ParticipantNumber == participant.ParticipantNumber);
            if (participant != null)
            {
                participant.Name = participant.Name;
                participant.Country = participant.Country;
                participant.Boat.Model = participant.Boat.Model;
                participant.Boat.Name = participant.Boat.Name;
                participant.CategoryAssignedByParticipant = participant.CategoryAssignedByParticipant;
                participant.Boat.SailNumber = participant.Boat.SailNumber;
                participant.ParticipantNumber = participant.ParticipantNumber;
                participant.Boat.Colour = participant.Boat.Colour;
                participant.Boat.Length = participant.Boat.Length;
            }
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
