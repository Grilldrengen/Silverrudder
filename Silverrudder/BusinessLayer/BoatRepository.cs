using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public class BoatRepository
    {
        public static void Create(Boat boat)
        {
        }

        public static void Delete(Boat boat)
        {
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
