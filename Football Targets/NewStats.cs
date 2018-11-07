using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//allow the user to update weekly stats past week 6

namespace Football_Targets
{
    class NewStats
    {
        private List<Player> _stats = new List<Player>();

        public List<Player> Stats { get { return _stats; } }

        public void AddStats(IEnumerable<Player> players)
        {
            _stats.AddRange(players);
        }
    }
}
