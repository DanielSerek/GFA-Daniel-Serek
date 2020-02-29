using System;
using Xunit;

namespace Anagram
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("kolorit", "tirolok")]
        public void Test1(string str1, string str2)
        {
            Anagram anagram = new Anagram();
            Assert.True(anagram.TestAnagram(str1, str2));
        }
    }
}
