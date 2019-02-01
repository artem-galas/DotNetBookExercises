using System;
using Xunit;
using ShapeLibrary;

namespace ShapeLibTests
{
    public class SquareTests
    {
        [Fact]
        public void Square_Should_Create()
        {
            var square = new Square(2);

            Assert.IsType<Square>(square);
        }

        [Fact]
        public void Area_2_Should_Return_4()
        {
            var square = new Square(2);
            var actual = square.Area();
            var expected = 4;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Area_4_7_Should_Return_22_09()
        {
            var square = new Square(4.7);
            double actual = square.Area();
            double expected = 22.09D;

            Assert.Equal(expected, actual, 1);   
        }

        [Fact]
        public void Static_Area_2_Should_Return_4()
        {
            var actual = Square.Area(2);
            var expected = 4;

            Assert.Equal(expected, actual);
        }

    }
    
}