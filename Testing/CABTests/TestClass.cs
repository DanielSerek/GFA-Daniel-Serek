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

        [Theory]
        [InlineData("abcd")]
        [InlineData("12345")]
        [InlineData("0")]
        public void CheckUserInputTest_FalseInput(string guess)
        {
            CowsAndBulls game = new CowsAndBulls();
            Assert.False(game.CheckUserInput(guess));
        }

        [Fact]
        public void CheckUserInputTest_CorrectInput()
        {
            CowsAndBulls game = new CowsAndBulls();
            Assert.True(game.CheckUserInput("1234"));
        }

        [Fact]
        public void GuessTest_Cows4()
        {
            CowsAndBulls game = new CowsAndBulls();
            game.Guess("1234", "1234");
            Assert.Equal(4, game.GuessedCows);
        }

        [Fact]
        public void GuessTest_Cows2Bulls2()
        {
            CowsAndBulls game = new CowsAndBulls();
            game.Guess("1100", "1010");
            Assert.Equal(2, game.GuessedCows);
            Assert.Equal(2, game.GuessedBulls);
        }
    }
}
