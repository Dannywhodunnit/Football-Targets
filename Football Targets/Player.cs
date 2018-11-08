using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "NAME")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "POS")]
        public Position Position { get; set; }
        [JsonProperty(PropertyName = "WK1")]
        public int wk1 { get; set; }
        [JsonProperty(PropertyName = "WK2")]
        public int wk2 { get; set; }
        [JsonProperty(PropertyName = "WK3")]
        public int wk3 { get; set; }
        [JsonProperty(PropertyName = "WK4")]
        public int wk4 { get; set; }
        [JsonProperty(PropertyName = "WK5")]
        public int wk5 { get; set; }
        [JsonProperty(PropertyName = "WK6")]
        public int wk6 { get; set; }
        [JsonProperty(PropertyName = "TOTAL\nTGTS")]
        public int totalTgts { get; set; }
        [JsonProperty (PropertyName = "AVG\nTGTS")]
        public double avgTgts { get; set; }
        [JsonProperty(PropertyName = "CATCH")]
        public int ctch { get; set; }
        [JsonProperty(PropertyName = "CATCH\nPRCNT")]
        public double catchPrcnt { get; set; }
        [JsonProperty(PropertyName = "TD")]
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
