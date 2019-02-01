using System;
using Xunit;
using ShapeLibrary;

namespace ShapeLibTests
{
    public class RectangleTests
    {
        [Fact]
        public void Rectangle_Should_Create()
        {
            var rectangle = new Rectangle(2, 4);

            Assert.IsType<Rectangle>(rectangle);
        }

        [Fact]
        public void Area_2_4_Should_Return_8()
        {
            var rectangle = new Rectangle(2, 4);
            var actual = rectangle.Area();
            var expected = 8;

            Assert.Equal<double>(expected, actual);
        }

        [Fact]
        public void Static_Area_2_4_Should_Return_8()
        {
            var actual = Rectangle.Area(2, 4);
            var expected = 8;

            Assert.Equal(expected, actual);
        }
    }
}