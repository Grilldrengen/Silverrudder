using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Boat
    {
        public string Name { get; set; }
        public string SailNumber { get; set; }
        public string Model { get; set; }
        public float Length { get; set; }
        public string Colour { get; set; }
        public string CategoryAssignedByParticipant { get; set; }

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
