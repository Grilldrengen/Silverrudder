using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public ObservableCollection<Participant> Participants { get; set; }

        public Category()
        {
            this.Participants = new ObservableCollection<Participant>();
        }

        public Category(string name)
        {
            this.Name = name;
            this.Participants = new ObservableCollection<Participant>();
        }

        public Category(string name, DateTime startTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.Participants = new ObservableCollection<Participant>();
        }
    }
}