using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tanks.Contracts
{
    [DataContract]
    public class Map
    {
        [DataMember]
        public List<MapItem> MapItems { get; set; }
    }
}
