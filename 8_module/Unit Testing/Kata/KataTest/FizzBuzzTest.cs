using Kata;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [TestCase(1, "1")]
        [TestCase(16, "16")]
        [TestCase(98, "98")]
        public void Numbers_With_No_Special_Properties_Return_Number(int num, string expected)
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();
            // Act
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            // Assert
            Assert.AreEqual(expected, actual);
        }
                
        [TestCase(12)]
        [TestCase(81)]
        [TestCase(99)]      
        public void Numbers_Divisible_By_Three_But_Not_Five_Return_Fizz(int num)
        {           
            var fizzBuzz = new FizzBuzz(); 
            var expected = "Fizz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5)]
        [TestCase(25)]
        [TestCase(100)]
        public void Numbers_Divisible_By_Five_But_Not_Three_Return_Buzz(int num)
        {
            var fizzBuzz = new FizzBuzz();
            var expected = "Buzz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }
              
        [TestCase(45)]
        [TestCase(75)]
        [TestCase(90)]
        public void Numbers_Divisible_By_Five_And_Three_Return_FizzBuzz(int num)
        {           
            var fizzBuzz = new FizzBuzz();
            var expected = "FizzBuzz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-15)]
        [TestCase(101)]
        public void Numbers_MoreThan_Hundred_Or_LessThan_One_Return_Exception(int num)
        {
            var fizzBuzz = new FizzBuzz();
            Assert.That(() => fizzBuzz.CheckForFizzBuzz(num), Throws.InvalidOperationException);
        }

    }
}