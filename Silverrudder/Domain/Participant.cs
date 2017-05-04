using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public class Participant : ModelBase
    {

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                if (value != country)
                {
                    country = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int participantNumber;
        public int ParticipantNumber
        {
            get { return participantNumber; }
            set
            {
                if (value != participantNumber)
                {
                    participantNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string categoryAssignedByParticepant;
        public string CategoryAssignedByParticipant
        {
            get { return categoryAssignedByParticepant; }
            set
            {
                if (value != categoryAssignedByParticepant)
                {
                    categoryAssignedByParticepant = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Boat boat;
        public Boat Boat
        {
            get { return boat; }
            set
            {
                if (value != boat)
                {
                    boat = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Participant()
        { }

        public Participant(string name)
        {
            this.Name = name;
        }

        public Participant(string name, int participantNumber, string country, Boat boat)
        {
            this.Name = name;
            this.ParticipantNumber = participantNumber;
            this.Country = country;
            this.Boat = boat;
        }
    }
}
