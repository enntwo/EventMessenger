using Data;
using EventMessenger.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventMessenger
{
    public class PostPairingsViewModel : ObservableObject
    {
        public DelegateCommand BrowseCommand { get; set; }
        private readonly PlayerRepository _playerRepository;

        private string _selectedFilePath;
        public string SelectedFilePath
        {
            get
            {
                return _selectedFilePath;
            }
            set
            {
                SetProperty(ref _selectedFilePath, value);
            }
        }

        private string _eventName;
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                SetProperty(ref _eventName, value);
            }
        }
        private string _roundText;
        public string RoundText
        {
            get
            {
                return _roundText;
            }
            set
            {
                SetProperty(ref _roundText, value);
            }
        }

        public PostPairingsViewModel(PlayerRepository playerRepository) : base()
        {
            _playerRepository = playerRepository;
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            BrowseCommand = new DelegateCommand(BrowseCommandHandler);
        }

        private void BrowseCommandHandler(object args)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".xps";
            fileDialog.AddExtension = true;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;

            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                SelectedFilePath = fileDialog.FileName;
                LoadXPSFile(SelectedFilePath);
            }
        }

        private void LoadXPSFile(string path)
        {
            string content = "";
            try
            {
                content = XpsConverter.ExtractText(path);
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to import pairings. \n Make sure the file is the proper format (.xps).");
                return;
            }

            if(content == "")
            {
                MessageBox.Show("Unable to import pairings. \n Make sure the file is the proper format (.xps).");
                return;
            }

            var lines = content.Split('\n');
            Pairing pairing = new Pairing();
            try
            {
                pairing.EventName = lines[2].Substring(7);
                pairing.RoundText = lines[3];

                var pairs = lines.Skip(6).TakeWhile(l => !l.StartsWith("Wizards Event Reporter"));
                foreach(var pair in pairs)
                {
                    string message = "Table {0}: {1}({2}) vs. {3}({4}) [{5}]";
                    var parts = pair.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim();
                    }

                    var player1 = _playerRepository.GetPlayer(parts[2]);
                    var player2 = _playerRepository.GetPlayer(parts[4]);

                    message = string.Format(message, parts);

                    pairing.Pairings.Add(new Tuple<Player, Player, string>(player1, player2, message));
                }
            }
            catch(Exception e)
            {
                 MessageBox.Show("Unable to import pairings. \n Make sure the file is the proper format (.xps).");
                 return;
            }

            PutPairingInContext(pairing);
        }

        private void PutPairingInContext(Pairing pairing)
        {
            EventName = pairing.EventName;
            RoundText = pairing.RoundText;
        }
    }
}
