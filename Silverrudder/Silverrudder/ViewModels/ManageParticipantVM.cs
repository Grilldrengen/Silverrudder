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
        private ParticipantRepository participantRepository = new ParticipantRepository();
        private BoatRepository boatRepository = new BoatRepository();

        public ICommand CommandCreateParticipant { get; set; }
        public ICommand CommandChangeParticipant { get; set; }
        public ICommand CommandDeleteParticipant { get; set; }

        #region Properties

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
                        BoatCategory = SelectedParticipant.Category;
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

            ParticipantsList = participantRepository.GetAll();
        }

        public bool CanExecuteCommandDeleteParticipant(object parameter)
        {
            return true;
        }

        public void ExecuteCommandDeleteParticipant(object parameter)
        {
            participantRepository.Delete(selectedParticipant);
        }

        public bool CanExecuteCommandChangeParticipant(object parameter)
        {
            return true;
        }

        public void ExecuteCommandChangeParticipant(object parameter)
        {
            participantRepository.Modify(SelectedParticipant, ParticipantProperties.Name, Captain);
            participantRepository.Modify(SelectedParticipant, ParticipantProperties.Country, Country);
            participantRepository.Modify(SelectedParticipant, ParticipantProperties.ParticipantNumber, ParticipantNumber);

            boatRepository.Modify(selectedParticipant.Boat, BoatProperties.Colour, BoatColour);
            boatRepository.Modify(selectedParticipant.Boat, BoatProperties.Length, BoatLength.ToString());
            boatRepository.Modify(selectedParticipant.Boat, BoatProperties.Model, BoatType);
            boatRepository.Modify(selectedParticipant.Boat, BoatProperties.Name, BoatName);
            boatRepository.Modify(selectedParticipant.Boat, BoatProperties.SailNumber, SailNumber);

            //SelectedParticipant.Boat.Name = BoatName;
            //SelectedParticipant.Boat.SailNumber = SailNumber;
            //SelectedParticipant.Boat.Colour = BoatColour;
            //SelectedParticipant.Boat.Length = BoatLength;
            //SelectedParticipant.Boat.Model = BoatType;

            //SelectedParticipant.Name = Captain;
            //SelectedParticipant.Country = Country;
            //SelectedParticipant.Category = BoatCategory;
            //SelectedParticipant.ParticipantNumber = participantNumber;


        }

        public bool CanExecuteCommandCreateParticipant(object parameter)
        {
            if (participantNumber == 0)
                return false;

            int result;
            if (!int.TryParse(ParticipantNumber, out result))                
                return false;

            if (Captain == null)
                return false;

            if (BoatName == null)
                return false;

            return true;
        }

        public void ExecuteCommandCreateParticipant(object parameter)
        {
            Boat boat = new Boat();

            boat.Name = BoatName;
            boat.SailNumber = SailNumber;
            boat.Colour = BoatColour;
            boat.Length = BoatLength;
            boat.Model = BoatType;

            Participant participant = new Participant();

            participant.Name = Captain;
            participant.Country = Country;
            participant.Category = BoatCategory;
            participant.ParticipantNumber = participantNumber;

            participant.Boat = boat;

            participantRepository.Create(participant);
        }
    }
}
