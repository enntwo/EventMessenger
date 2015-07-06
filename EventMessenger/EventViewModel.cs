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
    public class EventViewModel : ObservableObject
    {
        private readonly IPlayerRepository _playerRepository;
        private int _eventId;
        private Player _selectedAvailablePlayer;
        private Player _selectedEventPlayer;

        public DelegateCommand AddToEventCommand { get; private set; }
        public DelegateCommand RemoveFromEventCommand { get; private set; }

        public Player SelectedAvailablePlayer
        {
            get
            {
                return _selectedAvailablePlayer;
            }
            set
            {
                SetProperty(ref _selectedAvailablePlayer, value);
                AddToEventCommand.RaiseCanExecuteChanged();
            }
        }

        public Player SelectedEventPlayer
        {
            get
            {
                return _selectedEventPlayer;
            }
            set
            {
                SetProperty(ref _selectedEventPlayer, value);
                RemoveFromEventCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Player> AvailablePlayers
        {
            get { return _playerRepository.AllPlayers.Where(player => !player.Events.Contains(EventId)).ToObservableCollection<Player>(); }
        }

        public ObservableCollection<Player> PlayersInEvent
        {
            get { return _playerRepository.AllPlayers.Where(player => player.Events.Contains(EventId)).ToObservableCollection<Player>(); }
        }

        public int EventId
        {
            get { return _eventId; }
        }

        public EventViewModel(int eventId, IPlayerRepository playerRepository)
        {
            this._eventId = eventId;
            this._playerRepository = playerRepository;
            InitalizeData();
            InitalizeCommands();
        }

        public void InitalizeData()
        {

        }

        public void InitalizeCommands()
        {
            this.AddToEventCommand = new DelegateCommand(args => AddToEventCommandHandler(args), args => CanAddToEvent(args));
            this.RemoveFromEventCommand = new DelegateCommand(args => RemoveFromEventCommandHandler(args), args => CanRemoveFromEvent(args));
        }

        #region Command Methods

        public void AddToEventCommandHandler(object args)
        {
            if (SelectedAvailablePlayer != null)
            {
                SelectedAvailablePlayer.Events.Add(EventId);
                OnPropertyChanged("AvailablePlayers");
                OnPropertyChanged("PlayersInEvent");
            }
        }

        public bool CanAddToEvent(object args)
        {
            return SelectedAvailablePlayer != null;
        }

        public void RemoveFromEventCommandHandler(object args)
        {
            if (SelectedEventPlayer != null && SelectedEventPlayer.Events.Contains(EventId))
            {
                SelectedEventPlayer.Events.Remove(EventId);
                OnPropertyChanged("AvailablePlayers");
                OnPropertyChanged("PlayersInEvent");
            }
        }

        public bool CanRemoveFromEvent(object args)
        {
            return SelectedEventPlayer != null;
        }

        #endregion
    }
}
