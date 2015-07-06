using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Pairing
    {
        public string EventName;
        public string RoundText;
        public bool IsRepair;

        public List<Tuple<Player, Player>> Pairings;
 
        public Pairing() 
        {
            Pairings = new List<Tuple<Player, Player>>();
        }
    }
}
