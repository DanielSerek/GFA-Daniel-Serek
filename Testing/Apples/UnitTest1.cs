using System;
using System.Collections.Generic;
using Xunit;

namespace Apples
{
    public class UnitTest1
    {
        /*
            Create a class, with one method (eg. public string GetApple()) that returns a string (eg. "apple")
            Create a test for that.
            Create an xUnit project
            Add a new Test case in it
            Instantiate your class (arrange, act, assert)
            Use the Assert.Equal()
            The expected parameter should be the same string (eg. "apple")
            The actual parameter should be the return value of the method (eg. myObject.GetApple())
            Run the test
            Change the expected value to make the test failing
            Run the test
            Fix the returned value to make the test succeeding again
        */
        
        [Fact]
        public void Test1()
        {
            //arrange
            var apple = new Apples();
            var output = apple.GetApple();

            //assert
            Assert.Equal("apple", output);
            
        }
        /*
        Create a sum method in your class which takes a List of integers as parameter
        It should return the sum of the elements in the list
        Follow these steps:
        Create an xUnit project
        Add a Test class to your project
        Add a new Test case in it
        Instantiate your class (arrange, act, assert)
        create a list of integers
        use the Assert.Equal() to test the result of the created sum method
        Run them
        Create different tests where you test your method with:
        an empyt list
        a list that has one element in it
        a list that has multiple elements in it
        a null
        Run them
        Fix your code if needed
        */

        [Fact]
        public void TestSum()
        {
            Sum sum1 = new Sum();
            List<int> numbers = new List<int> { 1, 2, 3 };
            var output = sum1.SumOfTheList(numbers);
            Assert.Equal(6, output);
        }

        [Fact]
        public void TestSumEmptyList()
        {
            Sum sum1 = new Sum();
            List<int> numbers = new List<int>(3);
            var output = sum1.SumOfTheList(numbers);
            Assert.Equal(0, output);
        }

        [Fact]
        public void TestSumNull()
        {
            Sum sum1 = new Sum();
            Assert.Equal(0, sum1.SumOfTheList(null));
        }
    }
}
