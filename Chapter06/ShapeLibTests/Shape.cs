using System;
using Xunit;
using ShapeLibrary;

namespace ShapeLibTests
{
    public class ShapeTests
    {
        [Fact]
        public void Area_Should_Throw_NotImplementedException()
        {
            var shape = new Shape();
            Action action = () => shape.Area();

            Assert.Throws<NotImplementedException>(action);
        }
    }
}
