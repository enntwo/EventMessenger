using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PlayerRepository : IPlayerRepository
    {
        string path = @".\";
        string playersFile = @"players.json";
        string tempFile = @"temp.json";

        ObservableCollection<Player> _allPlayers;

        public ObservableCollection<Player> AllPlayers
        {
            get { return _allPlayers; }
            set { _allPlayers = value; }
        }   

        public PlayerRepository()
        {
            _allPlayers = new ObservableCollection<Player>();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            if(Directory.Exists(path))
            {
                try
                {
                    using (var fs = File.Open(Path.Combine(path, playersFile), FileMode.Open, FileAccess.Read))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Player>));

                        _allPlayers = (ObservableCollection<Player>)serializer.ReadObject((Stream)fs);
                    }
                }
                catch(Exception e)
                {
                    // TODO:Error
                    // Couldn't open serialized file.
                }
            }
        }

        public void AddPlayer(Player player)
        {
            _allPlayers.Add(player);
        }

        public void SavePlayers()
        {
            try
            {
                using(var temp = File.Open(Path.Combine(path, tempFile), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Player>));
                    serializer.WriteObject((Stream)temp, _allPlayers);
                }

                File.Copy(Path.Combine(path, tempFile), Path.Combine(path, playersFile), true);
            }
            catch(Exception e)
            {
                   // TODO:Error
                    // Couldn't save serialized file.
            }
        }
    }
}
