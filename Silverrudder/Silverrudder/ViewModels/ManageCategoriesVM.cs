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
        public ICommand CommandCreateCategory { get; set; }
        public ICommand CommandChangeCategory { get; set; }
        public ICommand CommandDeleteCategory { get; set; }
        public ICommand CommandDivideCategory { get; set; }


    }
}
