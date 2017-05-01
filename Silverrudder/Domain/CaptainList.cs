using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CaptainList
    {
        private static readonly CaptainList _instance = new CaptainList();

        public static CaptainList Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<Captain> captainList = new List<Captain>();

        public CaptainList()
        {
        }
    }
}
