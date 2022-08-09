using MegaprimesFinder.Engine.Helpers;
using Xunit;

namespace MegaprimesFinderTests.Engine.Helpers
{
    public class IntHelpersTests
    {
        IntHelpers _intHelpers;
        public IntHelpersTests()
        {
            _intHelpers = new IntHelpers();
        }

        public class DigitSplitter : IntHelpersTests
        {
            [Fact]
            public void ShouldSplitNumberToDigits()
            {
                List<int> splittedDigits = new List<int>() { 1, 2, 3 };
                Assert.Equal(splittedDigits, _intHelpers.DigitSplitter(123));
            }
        }

        public class GroupNumbers : IntHelpersTests
        {
            [Fact]
            public void Inputting_99_Should_Return_99_Partitions()
            {
                var numbers = AddNumbersToList(99);
                Assert.Equal(99, _intHelpers.GroupNumbers(numbers).Count);
            }

            [Fact]
            public void Inputting_100_Should_Return_1_Partition()
            {
                var numbers = AddNumbersToList(100);
                Assert.Equal(1, _intHelpers.GroupNumbers(numbers).Count);
            }

            [Fact]
            public void Inputting_10000_Should_Return_100_Partition()
            {
                var numbers = AddNumbersToList(10000);
                Assert.Equal(100, _intHelpers.GroupNumbers(numbers).Count);
            }

            [Fact]
            public void Inputting_10001_Should_Return_11_Partition()
            {
                var numbers = AddNumbersToList(10001);
                Assert.Equal(11, _intHelpers.GroupNumbers(numbers).Count);
            }
        }

        private List<int> AddNumbersToList(int maxNumber)
        {
            var numbers = new List<int>();
            for (int i = 1; i < maxNumber+1; i++)
                numbers.Add(i);
            return numbers;
        }

    }
}