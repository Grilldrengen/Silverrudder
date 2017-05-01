using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public class Captain
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public int ParticipantNumber { get; set; }
        public Boat Boat { get; set; }

        public Captain()
        { }

        public Captain(string name)
        {
            this.Name = name;
        }

        public Captain(string name, int participantNumber, string country, Boat boat)
        {
            this.Name = name;
            this.ParticipantNumber = participantNumber;
            this.Country = country;
            this.Boat = boat;
        }
    }
}
