using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Logic.Wrappers;

namespace UnitTest.Logic.Tests
{
    [TestClass()]
    public class MyNumbersWithStaticMethodsTests
    {
        [TestMethod()]
        public void SumNumbers_ShouldReturnSuccessResult()
        {
            // Arrange
            // Arrange
            var wrapper = new MyNumbersWrapper();
            var myNumbers = new MyNumbersWithStaticMethods(wrapper);
            var numOne = 7;
            var numTwo = 5;
            var expectedResult = 12;
            var actualResult = 0;

            // Act 
            actualResult = myNumbers.SumNumbers(numOne, numTwo);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}