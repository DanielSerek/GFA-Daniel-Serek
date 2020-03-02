using System;
using Xunit;
using CAB;

namespace CABTests
{
    public class TestClass
    {
        [Fact]
        public void ConstructorTest() 
        {
            CowsAndBulls game = new CowsAndBulls();
            Assert.Equal("Playing", game.Status);
            Assert.Equal(0, game.Guesses);
        }
        
        [Fact]
        public void RandomNumberTest_ProperLength()
        {
            CowsAndBulls game = new CowsAndBulls();
            Assert.Equal(4, game.RandomNumber().Length);
        }

        [Fact]
        public void RandomNumberTest_ContainsNumbers()
        {
            CowsAndBulls game = new CowsAndBulls();
            Assert.True(Int32.Parse(game.RandomNumber()) >= 0 && Int32.Parse(game.RandomNumber()) <= 9999);
        }


    }
}
