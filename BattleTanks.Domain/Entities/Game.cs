using System.Collections.Generic;
using System.Linq;

namespace BattleTanks.Domain.Entities
{
    public struct Game
    {
        public List<Tank> Tanks { get; }

        public Game(IEnumerable<Tank> tanks)
        {
            Tanks = tanks.ToList();
        }
    }
}
