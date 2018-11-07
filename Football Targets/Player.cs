using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Targets
{

    public class RootObject
    {
        public Player[] Player { get; set; }
    }

    public class Player : System.IComparable<Player>
    {
        public string name { get; set; }
        public Position Position { get; set; }
        public int wk1 { get; set; }
        public int wk2 { get; set; }
        public int wk3 { get; set; }
        public int wk4 { get; set; }
        public int wk5 { get; set; }
        public int wk6 { get; set; }
        public int totalTgts { get; set; }
        public double avgTgts { get; set; }
        public int ctch { get; set; }
        public double catchPrcnt { get; set; }
        public int touchDown { get; set; }

        public int CompareTo(Player that)
        {
            int result = this.name.CompareTo(that.name);
            
            if(result == 0)
            {
                result = this.wk1.CompareTo(that.totalTgts);

            }
            return result;
        }
    }
    public enum Position
    {
        TE,
        WR,
        RB
    }

}
