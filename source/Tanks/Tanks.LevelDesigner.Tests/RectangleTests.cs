using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tanks.LevelDesigner.Model;

namespace Tanks.LevelDesigner.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void IntersectsItself()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 1,
                Y = 1,
                Size = 1
            };

            Assert.IsTrue(rectangle1.Intersect(rectangle1));
        }

        [TestMethod]
        public void IntersectsLeftTop()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 2,
                Y = 2,
                Size = 2
            };

            Rectangle rectangle2 = new Rectangle
            {
                X = 1,
                Y = 1,
                Size = 2
            };

            Assert.IsTrue(rectangle1.Intersect(rectangle2));
        }

        [TestMethod]
        public void IntersectsRightBottom()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 2,
                Y = 2,
                Size = 2
            };

            Rectangle rectangle2 = new Rectangle
            {
                X = 3,
                Y = 3,
                Size = 2
            };

            Assert.IsTrue(rectangle1.Intersect(rectangle2));
        }

        [TestMethod]
        public void IntersectsIn()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 2,
                Y = 2,
                Size = 4
            };

            Rectangle rectangle2 = new Rectangle
            {
                X = 3,
                Y = 3,
                Size = 2
            };

            Assert.IsTrue(rectangle1.Intersect(rectangle2));
        }

        [TestMethod]
        public void IntersectsOut()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 2,
                Y = 2,
                Size = 2
            };

            Rectangle rectangle2 = new Rectangle
            {
                X = 1,
                Y = 1,
                Size = 4
            };

            Assert.IsTrue(rectangle1.Intersect(rectangle2));
        }

        [TestMethod]
        public void NotIntersects()
        {
            Rectangle rectangle1 = new Rectangle
            {
                X = 2,
                Y = 2,
                Size = 2
            };

            Rectangle rectangle2 = new Rectangle
            {
                X = 4,
                Y = 4,
                Size = 4
            };

            Assert.IsFalse(rectangle1.Intersect(rectangle2));
        }
    }
}
