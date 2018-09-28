using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problems
{
    /// <summary>
    /// Problems for the website https://projecteuler.net.
    /// </summary>
    public class ProjectEuler
    {
        /// <summary>
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns>Long, the sum of multiples of 3 or 5 below 1000.</returns>
        public static long Problem1()
        {
            long sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            return sum;
        }

        /// <summary>
        /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns>Long, sum of even-valued Fibonacci numbers less than 4 million.</returns>
        public static long Problem2()
        {
            long sum = 0;
            Dictionary<long, long> fib = new Dictionary<long, long>
            {
                { 0, 1 },
                { 1, 1 }
            };
            for (int i = 2; ; i++)
            {
                var val = fib[i - 1] + fib[i - 2];
                if (val > 4000000)
                    break;

                fib.Add(i, val);
            }
            foreach (var val in fib.Values)
                sum = val % 2 == 0 ? sum + val : sum;

            return sum;
        }

        /// <summary>
        /// What is the largest prime factor of the number 600851475143?
        /// </summary>
        /// <returns>Long, prime factor of 600851475143</returns>
        public static long Problem3()
        {
            List<long> facs = new List<long>();
            long d = 2;
            long n = 600851475143;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    facs.Add(d);
                    n /= d;
                }
                d += 1;
                if (d * d > n)
                {
                    if (n > 1)
                        facs.Add(n);
                    break;
                }
            }

            return facs.Max();
        }

        /// <summary>
        /// Find the largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        /// <returns>Long, largest palindrome made from product of two 3-digit numbers.</returns>
        public static long Problem4()
        {
            long max = 0;
            for (int i = 999; i > 0; i--)
                for (int j = 999; j > 0; j--)
                    if (IsPalindromeNumber(i * j) && i * j > max)
                        max = i * j;

            return max;
        }

        /// <summary>
        ///  Check if a number is a palindrome.
        /// </summary>
        /// <typeparam name="T">Type of number to check.</typeparam>
        /// <param name="n">Number to check.</param>
        /// <returns>True if the number is a palindrome, else false.</returns>
        static bool IsPalindromeNumber<T>(T n)
        {
            var s = n.ToString();
            var sr = new string(s.Reverse().ToArray());

            return s.Equals(sr);
        }

        /// <summary>
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        /// <returns>Long, smallest number divisible by 1 to 20.</returns>
        public static long Problem5()
        {
            int n = 20 * 20 * 20 * 20 * 20;
            for (; ; n += 20)
            {
                bool d = true;
                for (int i = 20; i > 1; i--)
                {
                    if (n % i != 0)
                    {
                        d = false;
                        break;
                    }
                }
                if (d)
                    break;
            }
            return n;
        }

    }
}
