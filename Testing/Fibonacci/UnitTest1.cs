using System;
using Xunit;

namespace Fibonacci
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Calculation calc = new Calculation();
            Assert.Equal(8, calc.Calculate(6));
        }
    }
}
