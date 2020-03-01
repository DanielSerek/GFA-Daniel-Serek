using Xunit;
using System.Collections.Generic;

namespace Extension
{
    public class ExtensionTests
    {
        Extension extension = new Extension();

        [Fact]
        public void TestAdd_2and3is5()
        {
            Assert.Equal(6, extension.Add(3, 3));
        }

        [Fact]
        public void TestAdd_1and4is5()
        {
            Assert.Equal(5, extension.Add(1, 4));
        }

        [Fact]
        public void TestMaxOfThree_First()
        {
            Assert.Equal(9, extension.MaxOfThree(9, 6, 3));
        }

        [Fact]
        public void TestMaxOfThree_Second()
        {
            Assert.Equal(6, extension.MaxOfThree(2, 6, 3));
        }

        [Fact]
        public void TestMaxOfThree_Third()
        {
            Assert.Equal(5, extension.MaxOfThree(3, 4, 5));
        }

        [Fact]
        public void TestMedian_Even()
        {
            Assert.Equal(22, extension.Median(new List<int>() { 3, 13, 7, 5, 21, 23, 23, 40, 23, 14, 12, 56, 23, 29 }));
        }

        [Fact]
        public void TestMedian_Odd()
        {
            Assert.Equal(15, extension.Median(new List<int>() { 10, 11, 13, 15, 16, 23, 26 }));
        }

        [Fact]
        public void TestIsVowel_a()
        {
            Assert.True(extension.IsVowel('a'));
        }

        [Fact]
        public void TestIsVowel_u()
        {
            Assert.True(extension.IsVowel('u'));
        }

        [Fact]
        public void testTranslate_bemutatkozik()
        {
            Assert.Equal("bevemuvutavatkovozivik", extension.Translate("bemutatkozik"));
        }

        [Fact]
        public void testTranslate_kolbice()
        {
            Assert.Equal("kovolbiviceve", extension.Translate("kolbice"));
        }
    }
}
