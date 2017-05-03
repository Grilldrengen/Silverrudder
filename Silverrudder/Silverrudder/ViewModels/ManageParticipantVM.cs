using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using UI.ViewModels;
using UI.Views;
using BusinessLayer;
using Domain;
using System.Collections.ObjectModel;

namespace UI.ViewModels
{
    class ManageParticipantVM : ViewModelBase
    {
        public ICommand CommandCreateParticipant { get; set; }

        private ObservableCollection<Participant> participantsList;
        public ObservableCollection<Participant> ParticipantsList
        {
            get { return participantsList; }
            set
            {
                if (value != participantsList)
                {
                    participantsList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region Properties

        private string captain;
        public string Captain
        {
            get { return captain; }
            set
            {
                if (value != captain)
                {
                    captain = value;
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

        private string boatType;
        public string BoatType
        {
            get { return boatType; }
            set
            {
                if (value != boatType)
                {
                    boatType = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string boatName;
        public string BoatName
        {
            get { return boatName; }
            set
            {
                if (value != boatName)
                {
                    boatName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string boatCategory;
        public string BoatCategory
        {
            get { return boatCategory; }
            set
            {
                if (value != boatCategory)
                {
                    boatCategory = value;
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

        private string boatColor;
        public string BoatColor
        {
            get { return boatColor; }
            set
            {
                if (value != boatColor)
                {
                    boatColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private float boatLength;
        public float BoatLength
        {
            get { return boatLength; }
            set
            {
                if (value != boatLength)
                {
                    boatLength = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public ManageParticipantVM()
        {
            CommandCreateParticipant = new Command(ExecuteCommandCreateParticipant, CanExecuteCommandCreateParticipant);

            
            ParticipantsList = ParticipantRepository.GetAll();
        }

        public bool CanExecuteCommandCreateParticipant(object parameter)
        {
            return true;
        }

        public void ExecuteCommandCreateParticipant(object parameter)
        {
            ParticipantRepository pr = new ParticipantRepository();
            Participant p = new Participant();
            Boat b = new Boat();

            b.Name = BoatName;
            b.SailNumber = SailNumber;
            b.Colour = BoatColor;
            b.Length = BoatLength;
            b.Model = BoatType;

            p.Name = Captain;
            p.Country = Country;
            p.CategoryAssignedByParticipant = BoatCategory;
            p.ParticipantNumber = ParticipantNumber;
            p.Boat = b;

            pr.Create(p);

            

            // Kode udføres når der trykkes OK
        }

        
    }
}
