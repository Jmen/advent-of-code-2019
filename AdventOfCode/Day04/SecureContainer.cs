using System;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    internal class Number
    {
        private readonly List<int> _digits = new List<int>();

        public Number(int number)
        {
            var numberString = Convert.ToString(number);
            
            _digits.Add(Convert.ToInt32(numberString[0]));
            _digits.Add(Convert.ToInt32(numberString[1]));
            _digits.Add(Convert.ToInt32(numberString[2]));
            _digits.Add(Convert.ToInt32(numberString[3]));
            _digits.Add(Convert.ToInt32(numberString[4]));
            _digits.Add(Convert.ToInt32(numberString[5]));
        }

        public int Digit(int index)
        {
            return _digits[index - 1];
        }
    }
    
    internal static class SecureContainer
    {

        public static int HowManyPossiblePasswords_Part_1(int beginning, int end)
        {
            var matches = 0;

            for (int index = beginning; index <= end; index++)
            {
                var number = new Number(index);
                
                matches += HasTwoNumbersAdjacent(number) && DigitsNeverDecrease(number) ? 1 : 0;
            }

            return matches;
        }
        
        public static int HowManyPossiblePasswords_Part_2(int beginning, int end)
        {
            var matches = 0;

            for (int index = beginning; index <= end; index++)
            {
                var number = new Number(index);
                
                matches += HasTwoNumbersAdjacentThatAreNotPartOfALargerGroupOfMatchingDigits(number) && DigitsNeverDecrease(number) ? 1 : 0;
            }

            return matches;
        }

        private static bool DigitsNeverDecrease(Number number)
        {
            return (number.Digit(2) >= number.Digit(1) && 
                    number.Digit(3) >= number.Digit(2) && 
                    number.Digit(4) >= number.Digit(3) && 
                    number.Digit(5) >= number.Digit(4) && 
                    number.Digit(6) >= number.Digit(5) );
        }

        private static bool HasTwoNumbersAdjacent(Number number)
        {
            return number.Digit(1) == number.Digit(2) ||
                   number.Digit(2) == number.Digit(3) ||
                   number.Digit(3) == number.Digit(4) ||
                   number.Digit(4) == number.Digit(5) ||
                   number.Digit(5) == number.Digit(6);
        }

        private static bool HasTwoNumbersAdjacentThatAreNotPartOfALargerGroupOfMatchingDigits(Number number)
        {
            var firstPair  = number.Digit(1) == number.Digit(2) && number.Digit(2) != number.Digit(3);
            var secondPair = number.Digit(2) == number.Digit(3) && number.Digit(1) != number.Digit(2) && number.Digit(3) != number.Digit(4);
            var thirdPair  = number.Digit(3) == number.Digit(4) && number.Digit(2) != number.Digit(3) && number.Digit(4) != number.Digit(5);
            var fourthPair = number.Digit(4) == number.Digit(5) && number.Digit(3) != number.Digit(4) && number.Digit(5) != number.Digit(6);
            var fifthPair = number.Digit(5) == number.Digit(6) && number.Digit(4) != number.Digit(5);

            return firstPair || secondPair || thirdPair || fourthPair || fifthPair;
        }
    }
}