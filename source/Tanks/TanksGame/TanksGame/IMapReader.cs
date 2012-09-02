using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.Contracts;

namespace TanksGame
{
    interface IMapReader
    {
        Map ReadMapForLevel(int level);
    }
}
