using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Domain;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UI.ViewModels
{
    class ManageCategoriesVM : ModelBase
    {
        CategoryRepository categoryrepository = new CategoryRepository();
        public ICommand CommandCreateCategory { get; set; }
        public ICommand CommandChangeCategory { get; set; }
        public ICommand CommandDeleteCategory { get; set; }
        public ICommand CommandDivideCategory { get; set; }

        public ManageCategoriesVM()
        {
            CommandCreateCategory = new Command(ExecuteCommandCreateCategory, CanExecuteCommandCreateCategory);
            CommandChangeCategory = new Command(ExecuteCommandChangeCategory, CanExecuteCommandChangeCategory);
            CommandDeleteCategory = new Command(ExecuteCommandDeleteCategory, CanExecuteCommandDeleteCategory);
            CommandDivideCategory = new Command(ExecuteCommandDivideCategory, CanExecuteCommandDivideCategory);

            CategoryList = categoryrepository.GetAll();
        }

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
                        
                    }

                }
            }
        }

        private ObservableCollection<Category> categoryList;
        public ObservableCollection<Category> CategoryList
        {
            get { return categoryList; }
            set
            {
                if (value != categoryList)
                {
                    categoryList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                if (value != categoryName)
                {
                    categoryName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if (value != startTime)
                {
                    startTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int numberOfParticipants;
        public int NumberOfParticipants
        {
            get { return numberOfParticipants; }
            set
            {
                if (value != numberOfParticipants)
                {
                    numberOfParticipants = value;
                    NotifyPropertyChanged();
                }
            }
        }


        #endregion

        private bool CanExecuteCommandDivideCategory(object parameter)
        {
            return true;
        }

        private void ExecuteCommandDivideCategory(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCommandDeleteCategory(object parameter)
        {
            return true;
        }

        private void ExecuteCommandDeleteCategory(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCommandChangeCategory(object parameter)
        {
            return true;
        }

        private void ExecuteCommandChangeCategory(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCommandCreateCategory(object parameter)
        {
            return true;
        }

        private void ExecuteCommandCreateCategory(object parameter)
        {
            Category c = new Category();

            c.Name = CategoryName;
            c.StartTime = StartTime;
            

            categoryrepository.Create(c);
            
        }

       


    }
}
