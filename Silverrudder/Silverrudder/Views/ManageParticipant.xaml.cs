using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ManageParticipant.xaml
    /// </summary>

    public partial class ManageParticipant : UserControl
    {
        private ManageParticipantVM viewModel { get; set; }

        public ManageParticipant()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            viewModel = new ManageParticipantVM();
            DataContext = viewModel;
        } 
    }
}
