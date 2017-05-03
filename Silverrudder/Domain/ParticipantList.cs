using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ParticipantList
    {
        private static readonly ParticipantList _instance = new ParticipantList();

        public static ParticipantList Instance
        {
            get
            {
                return _instance;
            }
        }
        public ObservableCollection<Participant> participantList = new ObservableCollection<Participant>();

        public ParticipantList()
        {
        }
    }
}
