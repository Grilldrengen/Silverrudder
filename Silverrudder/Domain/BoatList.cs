using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BoatList
    {
        private static readonly BoatList _instance = new BoatList();

        public static BoatList Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<Boat> boatList = new List<Boat>();

        public BoatList()
        {
        }
    }
}
