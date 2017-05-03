using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccesLayer;

namespace BusinessLayer
{
    public enum ParticipantProperties { Name, Country, ParticipantNumber};

    public class ParticipantRepository : IRepository<Participant, ParticipantProperties, string>
    {
        ImportCSVParticipantsFile importCSVParticipantsFile = new ImportCSVParticipantsFile();

        public void Create(Participant Participant)
        {
            ParticipantList.Instance.participantList.Add(Participant);
        }

        public void Delete(Participant Participant)
        {
            ParticipantList.Instance.participantList.Remove(Participant);
        }

        public bool Modify(Participant Participant, ParticipantProperties property, string newValue)
        {
            switch (property)
            {
                case ParticipantProperties.Name:
                    Participant.Name = newValue;
                    return true;

                case ParticipantProperties.Country:
                    if (newValue.Length == 3)
                    {
                        Participant.Country = newValue.ToUpper();
                        return true;
                    }
                    else
                        return false;

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

        public List<Participant> GetAll()
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

        public void GetParticipantsFromCSVFile(string path)
        {
            importCSVParticipantsFile.ReadCSVFile(path);
        }
    }
}
