using System;
using Xunit;
using AnimalWithTesting;

namespace AnimalTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAnimal1()
        {
            Animal cat = new Animal("Fiona", 33, 22);
            Assert.Equal("Fiona", cat.Name);
            cat.Eat();
            Assert.Equal(32, cat.Hunger);
        }

        [Fact]
        public void TestAnimal2()
        {
            Animal cat = new Animal("Fiona", 33, 22);
            cat.Eat();
            Assert.Equal(32, cat.Hunger);
        }
    }
}
