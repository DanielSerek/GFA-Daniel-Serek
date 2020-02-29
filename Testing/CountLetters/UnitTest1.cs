using System;
using System.Collections.Generic;
using Xunit;

namespace CountLetters
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("ssdfadaad")]
        public void Test1(string a)
        {
            CountLetters letters = new CountLetters();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            counts.Add("s", 2);
            counts.Add("d", 3);
            counts.Add("f", 1);
            counts.Add("a", 3);
            Assert.Equal(counts, letters.Letters(a));
        }

        
    }
}
