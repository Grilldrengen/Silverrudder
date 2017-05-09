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

            CategoriesList = categoryrepository.GetAll();
        }

        #region Properties

        private ObservableCollection<Category> categoriesList;
        public ObservableCollection<Category> CategoriesList
        {
            get { return categoriesList; }
            set
            {
                if (value != categoriesList)
                {
                    categoriesList = value;
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

            c.Name =
            c.StartTime =
            c.Participants =
            c.MinLength =
            c.MaxLength =

            categoryrepository.Create(c);
        }

       


    }
}
