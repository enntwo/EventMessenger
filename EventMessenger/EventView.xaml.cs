using Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Twilio;

namespace EventMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EventView : Window
    {
        public EventView()
        {
            InitializeComponent();            

            //repo.AddPlayer(new Player
            //{
            //    FullName = "Nick Blake",
            //    DCINumber = "1201959863",
            //    EmailAddress = "enntwo@gmail.com",
            //    Id = 1,
            //    PhoneNumber = "3393640933"
            //});
 
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.ShowDialog();
            //string text;
            //if (!String.IsNullOrEmpty(fileDialog.FileName))
            //    text = XpsConverter.ExtractText(fileDialog.FileName);

            //string AccountSid = "AC4e040c306543d01b437160a75d941c32";
            //string AuthToken = "560bb0fc0ab72fe6f0821ffffd5dd097";
            //var twilio = new TwilioRestClient(AccountSid, AuthToken);
            //Twilio.Message msg;
            //try
            //{
            //    msg = twilio.SendMessage("+13392300500", "3393640933", "body content");
            //    Console.WriteLine(msg.Sid); 
            //}
            //catch(Exception e)
            //{
            //    Console.Error.WriteLine(e.Message);
            //}
        }        
    }
}
