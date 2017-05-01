using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public enum CaptainProperties { Name, Country, ParticipantNumber};

    public class CaptainsRepository : IRepository<Captain, CaptainProperties, string>
    {
        public void Create(Captain captain)
        {
            CaptainList.Instance.captainList.Add(captain);
        }

        public void Delete(Captain captain)
        {
            CaptainList.Instance.captainList.Remove(captain);
        }

        public bool Modify(Captain captain, CaptainProperties property, string newValue)
        {
            switch (property)
            {
                case CaptainProperties.Name:
                    captain.Name = newValue;
                    return true;

                case CaptainProperties.Country:
                    if (newValue.Length == 3)
                    {
                        captain.Country = newValue.ToUpper();
                        return true;
                    }
                    else
                        return false;

                case CaptainProperties.ParticipantNumber:
                    bool result = TryParseStringToInt(newValue);
                    if (result == false)
                        return false;
                    else                    
                        captain.ParticipantNumber = int.Parse(newValue);
                        return true;
                    
                      default:
                    return false;
            }
        }

        public bool TryParseStringToInt(string value)
        {
            int participantNumber;
            bool res = int.TryParse(value, out participantNumber);

            if (res == true)
                return true;

            else return false;
        }
    }
}
