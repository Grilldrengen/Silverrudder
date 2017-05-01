using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{

    public class CaptainRepository : IRepository<Captain>
    {
        public void Create(Captain captain)
        {
            CaptainList.Instance.captainList.Add(captain);
        }

        public void Delete(Captain captain)
        {
            CaptainList.Instance.captainList.Remove(captain);
        }

        public void Modify(Captain captain)
        {
        }
    }
}
