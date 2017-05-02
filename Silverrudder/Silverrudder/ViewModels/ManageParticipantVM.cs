using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;
using UI.Views;

namespace UI.ViewModels
{
    public class ManageParticipantVM
    {
        public ICommand CommandCreateParticipant { get; set; }

        public ManageParticipantVM()
        {
            CommandCreateParticipant = new Command(ExecuteCommandCreateParticipant, CanExecuteCommandCreateParticipant);
        }

        public bool CanExecuteCommandCreateParticipant(object parameter)
        {
            if (true)
            {

            }
            return true;
        }

        public void ExecuteCommandCreateParticipant(object parameter)
        {
            
            // Kode udføres når der trykkes OK

        }
    }
}
