using System;
using System.Collections.Generic;

namespace Data
{
    public class Event
    {
        public Event()
        {
            Rounds = new List<Tuple<Player, Player>>();
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public List<Tuple<Player, Player>> Rounds;
    }
}
