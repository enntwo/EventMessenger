using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMessenger.Utilities;

namespace EventMessenger
{
    public class EditPlayersViewModel : ObservableObject
    {
        private readonly IPlayerRepository _playerRepository;
        private Player _selectedAvailablePlayer;
        private string _newPlayerName;
        private string _newPlayerDCINumber;
        private string _newPlayerPhoneNumber;
        private string _newPlayerEmailAddress; 
        private bool _newPlayerSendTexts;
        private bool _newPlayerSendEmails;

        public DelegateCommand RemovePlayerCommand { get; private set; }
        public DelegateCommand AddPlayerCommand { get; private set; }

        public string NewPlayerName
        {
            get
            {
                return _newPlayerName;
            }
            set
            {
                SetProperty(ref _newPlayerName, value == null ? null : value.Trim());
                OnPropertyChanged("FilteredAvailablePlayers");
                AddPlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public string NewPlayerDCINumber
        {
            get
            {
                return _newPlayerDCINumber;
            }
            set
            {
                SetProperty(ref _newPlayerDCINumber, value == null ? null : value.Trim());
                OnPropertyChanged("FilteredAvailablePlayers");
                AddPlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public string NewPlayerPhoneNumber
        {
            get
            {
                return _newPlayerPhoneNumber;
            }
            set
            {
                SetProperty(ref _newPlayerPhoneNumber, value == null ? null : value.Trim());
                OnPropertyChanged("FilteredAvailablePlayers");
                AddPlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public string NewPlayerEmailAddress
        {
            get
            {
                return _newPlayerEmailAddress;
            }
            set
            {
                SetProperty(ref _newPlayerEmailAddress, value == null ? null : value.Trim());
                OnPropertyChanged("FilteredAvailablePlayers");
                AddPlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public bool NewPlayerSendTexts
        {
            get
            {
                return _newPlayerSendTexts;
            }
            set
            {
                SetProperty(ref _newPlayerSendTexts, value);
            }
        }

        public bool NewPlayerSendEmails
        {
            get
            {
                return _newPlayerSendEmails;
            }
            set
            {
                SetProperty(ref _newPlayerSendEmails, value);
            }
        }

        public Player SelectedAvailablePlayer
        {
            get
            {
                return _selectedAvailablePlayer;
            }
            set
            {
                SetProperty(ref _selectedAvailablePlayer, value);
                RemovePlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Player> AvailablePlayers
        {
            get { return _playerRepository.AllPlayers; }
        }

        public ObservableCollection<Player> FilteredAvailablePlayers
        {
            get
            {
                return AvailablePlayers
                    .Where(p => String.IsNullOrWhiteSpace(NewPlayerName)
                        || p.FullName.ToLower().Contains(NewPlayerName.ToLower()))
                    .Where(p => String.IsNullOrWhiteSpace(NewPlayerDCINumber)
                        || p.DCINumber.ToLower().Contains(NewPlayerDCINumber.ToLower()))
                    .Where(p => String.IsNullOrWhiteSpace(NewPlayerEmailAddress)
                        || p.EmailAddress.ToLower().Contains(NewPlayerEmailAddress.ToLower()))
                    .Where(p => String.IsNullOrWhiteSpace(NewPlayerPhoneNumber)
                        || p.PhoneNumber.ToLower().Contains(NewPlayerPhoneNumber.ToLower())).ToObservableCollection();
            }
        }

        public EditPlayersViewModel(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
            InitalizeCommands();
        }

        public void InitalizeCommands()
        {
            this.RemovePlayerCommand = new DelegateCommand(args => RemovePlayerCommandHandler(args), args => CanRemovePlayer(args));
            this.AddPlayerCommand = new DelegateCommand(args => AddPlayerCommandHandler(args), args => CanAddPlayer(args));
        }

        #region Command Methods

        public void RemovePlayerCommandHandler(object args)
        {
            if (SelectedAvailablePlayer != null && AvailablePlayers.Contains(SelectedAvailablePlayer))
            {
                AvailablePlayers.Remove(SelectedAvailablePlayer);
                OnPropertyChanged("AvailablePlayers"); 
                OnPropertyChanged("FilteredAvailablePlayers");
            }
        }

        public bool CanRemovePlayer(object args)
        {
            return SelectedAvailablePlayer != null;
        }

        public void AddPlayerCommandHandler(object args)
        {
            AvailablePlayers.Add(
                new Player
                {
                    FullName = NewPlayerName,
                    DCINumber = NewPlayerDCINumber,
                    EmailAddress = NewPlayerEmailAddress,
                    PhoneNumber = NewPlayerPhoneNumber
                });

            AddPlayerCommand.RaiseCanExecuteChanged();
            OnPropertyChanged("AvailablePlayers");
            OnPropertyChanged("FilteredAvailablePlayers");
        }

        public bool CanAddPlayer(object args)
        {
            return !String.IsNullOrWhiteSpace(NewPlayerName)
                && !String.IsNullOrWhiteSpace(NewPlayerDCINumber)
                && !AvailablePlayers.Any(player => player.DCINumber == NewPlayerDCINumber.Trim());
        }
        #endregion
    }
}
