using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public string Name { get; set; }
        public float MinLength { get; set; }
        public float MaxLength { get; set; }
        public DateTime StartTime { get; set; }
        public List<Participant> participants { get; set; }
 
        public Category()
        { }

        public Category(string name)
        {
            this.Name = name;
        }

        public Category(string name, float minLength, float maxLength, DateTime startTime)
        {
            this.Name = name;
            this.MinLength = minLength;
            this.MaxLength = maxLength;
            this.StartTime = startTime;
        }        
    }
}
