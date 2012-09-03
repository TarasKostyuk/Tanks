using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.Contracts;

namespace TanksGame
{
    class MapReaderMock:IMapReader
    {
        public Map ReadMapForLevel(int level)
        {
            return new Map
            {
                MapItems = new List<MapItem>
                {
                    new MapItem
                    {
                        X = 5,
                        Y = 5,
                        ItemType = MapItemType.Head
                    },
                    new MapItem
                    {
                        X = 5,
                        Y = 5,
                        ItemType = MapItemType.Head
                    }
                }
            };
        }
    }
}
