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
using System.Windows.Shapes;

namespace EventMessenger
{
    /// <summary>
    /// Interaction logic for EditPlayersView.xaml
    /// </summary>
    public partial class EditPlayersView : Window
    {
        private EditPlayersViewModel _viewModel;

        public EditPlayersView()
        {
            _viewModel = ((App)App.Current).Resolve<EditPlayersViewModel>();
            this.DataContext = _viewModel;

            InitializeComponent();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.NewPlayerName = ((TextBox)sender).Text;
        }

        private void DCI_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.NewPlayerDCINumber = ((TextBox)sender).Text;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.NewPlayerEmailAddress = ((TextBox)sender).Text;
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.NewPlayerPhoneNumber = ((TextBox)sender).Text;
        }
    }
}
