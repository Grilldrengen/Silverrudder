using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Boat : ModelBase
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

        private string sailNumber;
        public string SailNumber
        {
            get { return sailNumber; }
            set
            {
                if (value != sailNumber)
                {
                    sailNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                if (value != model)
                {
                    model = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private float length;
        public float Length
        {
            get { return length; }
            set
            {
                if (value != length)
                {
                    length = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string colour;
        public string Colour
        {
            get { return colour; }
            set
            {
                if (value != colour)
                {
                    colour = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Boat()
        { }

        public Boat(string name, string sailNumber, string model, float length, string colour)
        {
            this.Name = name;
            this.SailNumber = sailNumber;
            this.Model = model;
            this.Length = length;
            this.Colour = colour;
        }
    }
}
