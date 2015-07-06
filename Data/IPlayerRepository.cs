using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPlayerRepository
    {
        ObservableCollection<Player> AllPlayers { get; set; }

        void SavePlayers();
        void AddPlayer(Player player);
        Player GetPlayer(string dci);
    }
}
