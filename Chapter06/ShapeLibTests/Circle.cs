using System;
using Xunit;
using ShapeLibrary;

namespace ShapeLibTests
{
    public class CircleTests
    {
        [Fact]
        public void Circle_Should_Create()
        {
            var circle = new Circle(2);

            Assert.IsType<Circle>(circle);
        }

        [Fact]
        public void Area_2_Should_Return_12_6()
        {
            var circle = new Circle(2);
            var actual = circle.Area();
            var expected = 12.6;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Area_4_3_Should_Return_58_1()
        {
            var circle = new Circle(4.3);
            var actual = circle.Area();
            var expected = 58.1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Static_Area_4_3_Should_Return_58_1()
        {
            var actual = Circle.Area(4.3);
            var expected = 58.1;

            Assert.Equal(expected, actual);
        }
    }
}
