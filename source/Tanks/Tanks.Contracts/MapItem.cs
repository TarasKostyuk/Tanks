using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tanks.Contracts
{
    [DataContract]
    public class MapItem
    {
        [DataMember]
        public int X
        {
            get;
            set;
        }

        [DataMember]
        public int Y
        {
            get;
            set;
        }

        [DataMember]
        public int Width
        {
            get;
            set;
        }

        [DataMember]
        public int Height
        {
            get;
            set;
        }

        [DataMember]
        public MapItemType ItemType
        {
            get;
            set;
        }
    }
}
