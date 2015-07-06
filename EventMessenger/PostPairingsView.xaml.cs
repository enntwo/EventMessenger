using Microsoft.Win32;
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
    /// Interaction logic for PostPairingsView.xaml
    /// </summary>
    public partial class PostPairingsView : Window
    {
        public PostPairingsView()
        {
            this.DataContext = ((App)App.Current).Resolve<PostPairingsViewModel>();

            InitializeComponent();
        }

       
    }
}
