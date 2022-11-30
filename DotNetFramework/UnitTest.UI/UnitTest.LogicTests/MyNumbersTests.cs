using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Common.Exceptions;

namespace UnitTest.Logic.Tests
{
    [TestClass()]
    public class MyNumbersTests
    {
        [TestMethod()]
        public void SumOnlyOdd_ShouldReturnSuccessResult()
        {
            // Arrange
            var myNumbers = new MyNumbers();
            var numOne = 7;
            var numTwo = 5;
            var expectedResult = 12;
            var actualResult = 0;

            // Act
            actualResult = myNumbers.SumOnlyOdd(numOne, numTwo);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod(), ExpectedException(typeof(OddNumberException))]
        public void SumOnlyOdd_ShouldThrowOddNumberEx()
        {
            // Arrange
            var myNumbers = new MyNumbers();
            var numOne = 10;
            var numTwo = 5;

            // Act
            myNumbers.SumOnlyOdd(numOne, numTwo);
        }
    }
}