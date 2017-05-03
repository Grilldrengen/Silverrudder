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
            return true;
        }

        public void ExecuteCommandCreateParticipant(object parameter)
        {
            ParticipantRepository pr = new ParticipantRepository();
            Participant p = new Participant();
        

            //p.Name = 
            


            //pr.Create(p);

            

            // Kode udføres når der trykkes OK
        }
    }
}
