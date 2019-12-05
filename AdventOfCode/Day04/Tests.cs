using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day04
{
    public class Tests
    {
        // ( ) six digit number
        // ( ) between the range of the input numbers
        // (x) range of one
        // (x) two adjacent digits are the same
        // (x) digits never decrease
        // (x) range of multiple numbers

        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }


        [Theory]
        [InlineData(112345, 112345, 1)]
        [InlineData(223456, 223456, 1)]
        [InlineData(122345, 122345, 1)]
        public void TwoAdjacentDigits(int beginning, int end, int expected)
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_1(beginning, end);

            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData(101111, 101111, 0)]
        [InlineData(110111, 110111, 0)]
        [InlineData(111011, 111011, 0)]
        [InlineData(111101, 111101, 0)]
        [InlineData(111110, 111110, 0)]
        public void DigitsNeverDecreaseTest(int beginning, int end, int expected)
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_1(beginning, end);

            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData(111111, 111111, 1)]
        [InlineData(223450, 223450, 0)]
        [InlineData(123789, 123789, 0)]
        public void Examples(int beginning, int end, int expected)
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_1(beginning, end);

            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData(111111, 111112, 2)]
        [InlineData(111111, 111113, 3)]
        public void CheckNumbersInBetweenRange(int beginning, int end, int expected)
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_1(beginning, end);

            result.ShouldBe(expected);
        }

        [Fact]
        public void Part1()
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_1(158126, 624574);

            _console.WriteLine(result.ToString());
        }

        [Fact]
        public void Example_Part2()
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_2(123444, 123444);

            result.ShouldBe(0);            
            
            var result2 = SecureContainer.HowManyPossiblePasswords_Part_2(111122, 111122);

            result2.ShouldBe(1);
            
            var result3 = SecureContainer.HowManyPossiblePasswords_Part_2(112233, 112233);

            result3.ShouldBe(1);
        }
        
        [Fact]
        public void Part2()
        {
            var result = SecureContainer.HowManyPossiblePasswords_Part_2(158126, 624574);

            _console.WriteLine(result.ToString());
        }
    }
}
