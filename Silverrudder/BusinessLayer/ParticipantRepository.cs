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
    public enum ParticipantProperties { Name, Country, ParticipantNumber }

    public class ParticipantRepository : IRepository<Participant, ParticipantProperties, string>
    {
        ImportCSVParticipantFromHPFile importCSVParticipantFromHPFile = new ImportCSVParticipantFromHPFile();
        SortParticipantAssignedCategory sortParticipantAssignedCategory = new SortParticipantAssignedCategory();

        private static readonly ParticipantRepository _instance = new ParticipantRepository();

        public static ParticipantRepository Instance
        {
            get
            {
                return _instance;
            }
        }
        public ObservableCollection<Participant> list = new ObservableCollection<Participant>();

        public void Create(Participant Participant)
        {
            Participant part = Instance.list.FirstOrDefault(p => p.ParticipantNumber == Participant.ParticipantNumber);
            if (part == null)
                Instance.list.Add(Participant);
        }

        public void Delete(Participant Participant)
        {
            Instance.list.Remove(Participant);
        }

        public bool Modify(Participant Participant, ParticipantProperties property, string newValue)
        {
            switch (property)
            {
                case ParticipantProperties.Name:
                    Participant.Name = newValue;
                    return true;

                case ParticipantProperties.Country:
                
                        Participant.Country = newValue.ToUpper();
                        return true;

                case ParticipantProperties.ParticipantNumber:
                    bool result = TryParseStringToInt(newValue);
                    if (result == false)
                        return false;
                    else
                        Participant.ParticipantNumber = int.Parse(newValue);
                    return true;

                default:
                    return false;
            }
        }

        public ObservableCollection<Participant> GetAll()
        {
            return Instance.list;
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
            sortParticipantAssignedCategory.StartSorting();
        }
    }
}
