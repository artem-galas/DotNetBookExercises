using System;
using System.Collections.Generic;
using Xunit;
using PrimeFactorLib;

namespace PrimeFactorUnitTests
{
    public class PrimeFactorUnitTest
    {
        [Fact]
        public void PrimeFactor_For_4()
        {
            var expected = new List<int> {2, 2};
            var actual = PrimeFactor.Calculate(4);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactor_For_30()
        {
            var expected = new List<int> {2, 3, 5};
            var actual = PrimeFactor.Calculate(30);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactor_For_40()
        {
            var expected = new List<int> {2, 2, 2, 5};
            var actual = PrimeFactor.Calculate(40);
            
            Assert.Equal(expected, actual);
        }
    }
}
