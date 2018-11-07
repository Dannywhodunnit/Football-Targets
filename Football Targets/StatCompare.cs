using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Targets
{
    class StatCompare : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.wk1.CompareTo(y.wk1) * -1;
        }
    }
}
