using System.Runtime.Serialization;

namespace Tanks.Contracts
{
    [DataContract(Name = "MI", Namespace = "")]
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

        [DataMember(Name = "IT")]
        public MapItemType ItemType
        {
            get;
            set;
        }
    }
}
