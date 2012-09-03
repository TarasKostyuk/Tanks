using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.Contracts
{
    [Serializable]
    public enum MapItemType
    {
        Empty,
        Brick,
        Head,
        Ice,
        Water,
        Wood,
        Concrete,
        P1Respawn,
        ERespawn,
        Bonus
    }
}
