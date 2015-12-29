using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars_IQTest
{
    public class IQ
    {
        public static int Test(string numbers)
        {
            int position = 0;

            int[] testNumbers = SeparateNumbers(numbers);
            int evens = CountEvens(testNumbers);
            int odds = CountOdds(testNumbers);

            if (odds > evens) //if number that differs is EVEN
            {
                position = FindDifferentNumber(testNumbers, true);
            }
            else //if number that differs is ODD
            {
                position = FindDifferentNumber(testNumbers, false);
            }

            return position;
        }

        public static int[] SeparateNumbers(string numbers)
        {
            string[] parsedNumbers = numbers.Split(' '); //split the numbers on the spaces.
            int[] finalNumbers = Array.ConvertAll(parsedNumbers, Convert.ToInt32); //Then convert them all to integers.

            return finalNumbers;
        }

        public static int CountEvens(int[] numbers)
        {
            int evens = 0;

            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                    evens++;
            }

            return evens;
        }

        public static int CountOdds(int[] numbers)
        {
            int odds = 0;

            foreach (int n in numbers)
            {
                if (n % 2 != 0)
                    odds++;
            }

            return odds;
        }

        //find the number that differs from the rest based on wether the parameter is odd or even
        public static int FindDifferentNumber(int[] numbers, bool even)
        {
            int position = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (even) //if the number that differs is even
                {
                    if (numbers[i] % 2 == 0) //test each number until you find the one that is divisible by 2 and return its position
                    {
                        position = i + 1;
                        continue;
                    }
                }
                else
                {
                    if (numbers[i] % 2 != 0) //test each number until you find the one that is NOT divisible by 2 and return its position
                    {
                        position = i + 1;
                        continue;
                    }
                }
            }

            return position;
        }
    }
}

//Bob is preparing to pass an IQ test. The most frequent task in this test is to find 
//out which one of the given numbers differs from the others. Bob observed that one 
//number usually differs from the others in evenness. Help Bob — to check his answers, 
//he needs a program that among the given numbers finds one that is different in 
//evenness, and return a position of this number.

//**Keep in mind that your task is to help Bob solve a real IQ test, which means 
//**indexes of the elements start from 1 (not 0)

//Examples:

//IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even

//IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers are odd