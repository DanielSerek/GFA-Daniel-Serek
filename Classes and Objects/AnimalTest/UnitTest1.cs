using System;
using Xunit;
using Animal;

namespace AnimalTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Animal cat = new Animal("Fiona", 33, 22);
        }
    }
}
