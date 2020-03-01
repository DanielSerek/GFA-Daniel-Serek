using System;
using Xunit;


namespace Animal
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Animal cat = new Animal("Fiona", 33, 22);
            Assert.Equal("Fiona", cat.Name);
        }
    }
}
