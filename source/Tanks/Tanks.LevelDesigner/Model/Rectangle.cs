namespace Tanks.LevelDesigner.Model
{
    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Size { get; set; }

        public bool Intersect(Rectangle rectangle)
        {
            if (X == rectangle.X && Y == rectangle.Y)
            {
                return true;
            }

            bool xIntersects = (X < rectangle.X && X + Size > rectangle.X ||
                                X < rectangle.X + rectangle.Size && X + Size > rectangle.X + rectangle.Size ||
                                X >= rectangle.X && X + Size <= rectangle.X + rectangle.Size);

            bool yIntersects = (Y < rectangle.Y && Y + Size > rectangle.Y ||
                                Y < rectangle.Y + rectangle.Size && Y + Size > rectangle.Y + rectangle.Size ||
                                Y >= rectangle.Y && Y + Size <= rectangle.Y + rectangle.Size);

            return xIntersects && yIntersects;
        }
    }
}