using System;
using System.Windows.Input;

namespace Tanks.LevelDesigner
{
    public class MapClickedEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MouseButton MouseButton { get; set; }
    }
}