using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public enum BoatProperties { Name, SailNumber, Model, Length, Colour };

    public class BoatRepository : IRepository<Boat, BoatProperties, string>
    {
        public void Create(Boat boat)
        {
        }

        public void Delete(Boat boat)
        {
        }

        public bool Modify(Boat boat, BoatProperties property, string newValue)
        {
            switch (property)
            {
                case BoatProperties.Name:
                    boat.Name = newValue;
                    return true;

                case BoatProperties.SailNumber:
                    boat.SailNumber = newValue;
                    return true;

                case BoatProperties.Model:
                    boat.Model = newValue;
                    return true;

                case BoatProperties.Length:
                    bool result = TryParseStringToInt(newValue);
                    if (result == false)
                        return false;
                    else
                        boat.Length = int.Parse(newValue);
                        return true;

                case BoatProperties.Colour:
                    boat.Colour = newValue;
                    return true;
                default:
                    return false;
            }
        }

        private bool TryParseStringToInt(string value)
        {
            int participantNumber;
            bool res = int.TryParse(value, out participantNumber);

            if (res == true)
                return true;

            else return false;
        }
    }
}
