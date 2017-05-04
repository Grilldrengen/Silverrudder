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
    class ManageParticipantVM : ModelBase
    {
        public ICommand CommandCreateParticipant { get; set; }
        public ICommand CommandChangeParticipant { get; set; }
        public ICommand CommandDeleteParticipant { get; set; }

        private Participant selectedParticipant;
        public Participant SelectedParticipant
        {
            get { return selectedParticipant; }
            set
            {
                if (value != selectedParticipant)
                {
                    selectedParticipant = value;
                    NotifyPropertyChanged();

                    if (SelectedParticipant != null)
                    {
                        BoatName = selectedParticipant.Boat.Name;
                        SailNumber = selectedParticipant.Boat.SailNumber;
                        BoatColour = SelectedParticipant.Boat.Colour;
                        BoatLength = SelectedParticipant.Boat.Length;
                        BoatType = SelectedParticipant.Boat.Model;

                        Captain = selectedParticipant.Name;
                        Country = SelectedParticipant.Country;
                        BoatCategory = SelectedParticipant.CategoryAssignedByParticipant;
                        participantNumber = SelectedParticipant.ParticipantNumber;
                    }

                }
            }
        }

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
        public string ParticipantNumber
        {
            get { return participantNumber.ToString(); }
            set
            {
                if (value != participantNumber.ToString())
                {
                    int.TryParse(value, out participantNumber);
                    NotifyPropertyChanged();
                }
            }
        }

        private string boatColour;
        public string BoatColour
        {
            get { return boatColour; }
            set
            {
                if (value != boatColour)
                {
                    boatColour = value;
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
            CommandChangeParticipant = new Command(ExecuteCommandChangeParticipant, CanExecuteCommandChangeParticipant);
            CommandDeleteParticipant = new Command(ExecuteCommandDeleteParticipant, CanExecuteCommandDeleteParticipant);

            ParticipantsList = ParticipantRepository.GetAll();
        }

        public bool CanExecuteCommandDeleteParticipant(object parameter)
        {
            return true;
        }

        public void ExecuteCommandDeleteParticipant(object parameter)
        {
            ParticipantRepository.Delete(selectedParticipant);
        }

        public bool CanExecuteCommandChangeParticipant(object parameter)
        {
            return true;
        }

        public void ExecuteCommandChangeParticipant(object parameter)
        {
            //ParticipantRepository.Change(selectedParticipant);
            SelectedParticipant.Boat.Name = BoatName;
            SelectedParticipant.Boat.SailNumber = SailNumber;
            SelectedParticipant.Boat.Colour = BoatColour;
            SelectedParticipant.Boat.Length = BoatLength;
            SelectedParticipant.Boat.Model = BoatType;

            SelectedParticipant.Name = Captain;
            SelectedParticipant.Country = Country;
            SelectedParticipant.CategoryAssignedByParticipant = BoatCategory;
            SelectedParticipant.ParticipantNumber = participantNumber;

        }

        public bool CanExecuteCommandCreateParticipant(object parameter)
        {
            if (participantNumber == 0)
                return false;

            int result;
            if (!int.TryParse(ParticipantNumber, out result))
                return false;

            return true;
        }

        public void ExecuteCommandCreateParticipant(object parameter)
        {

            Participant p = new Participant();
            Boat b = new Boat();

            b.Name = BoatName;
            b.SailNumber = SailNumber;
            b.Colour = BoatColour;
            b.Length = BoatLength;
            b.Model = BoatType;

            p.Name = Captain;
            p.Country = Country;
            p.CategoryAssignedByParticipant = BoatCategory;
            p.ParticipantNumber = participantNumber;
            p.Boat = b;

            ParticipantRepository.Create(p);
        }
    }
}
