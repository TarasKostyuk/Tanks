using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tanks.Contracts
{
    [DataContract(Name = "M", Namespace = "")]
    public class Map
    {
        public static Dictionary<MapItemType, int> MapItemSize
        {
            get
            {
                return new Dictionary<MapItemType, int>
                           {
                               {MapItemType.Bonus, 2},
                               {MapItemType.Brick, 1},
                               {MapItemType.Concrete, 1},
                               {MapItemType.ERespawn, 2},
                               {MapItemType.Head, 2},
                               {MapItemType.Ice,12},
                               {MapItemType.P1Respawn, 2},
                               {MapItemType.Water, 1},
                               {MapItemType.Wood, 1},
                           };
            }
        }

        public Map()
        {
            MapItems = new List<MapItem>();
        }

        [DataMember(Name = "MIs")]
        public List<MapItem> MapItems { get; set; }
    }
}
