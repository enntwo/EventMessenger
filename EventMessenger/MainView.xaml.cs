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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newPairingsView = new PostPairingsView();
            newPairingsView.ShowDialog();
            //var newEvent = EventViewFactory.CreateInstance();
            //newEvent.Show();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editPlayersView = new EditPlayersView();
            editPlayersView.ShowDialog();
        }
    }
}
