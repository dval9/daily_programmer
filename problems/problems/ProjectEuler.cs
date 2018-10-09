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

        /// <summary>
        /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        /// </summary>
        /// <returns>Long.</returns>
        public static long Problem6()
        {
            long n = 100 * 101 / 2;
            n *= n;
            for (int i = 1; i <= 100; i++)
                n -= i * i;

            return n;
        }

        /// <summary>
        /// What is the 10 001st prime number?
        /// </summary>
        /// <returns>Long.</returns>
        public static long Problem7()
        {
            int n = 10001;
            int lim = (int)Math.Ceiling(n * (Math.Log(n) + Math.Log(Math.Log(n))));
            int num_primes = 0;
            var sieve = SieveOfEratosthenes(lim);

            for (int i = 2; i < lim; i++)
            {
                if (sieve[i] == true)
                    num_primes++;
                if (num_primes == n)
                    return i;
            }

            return 0;
        }

        /// <summary>
        /// Generates Sieve of Eratosthenes up to integer n.
        /// </summary>
        /// <param name="n">Size of sieve.</param>
        /// <returns>bool[] containing the sieve.</returns>
        public static bool[] SieveOfEratosthenes(int n)
        {
            bool[] sieve = Enumerable.Repeat(true, n).ToArray();
            for (int i = 2; i < Math.Sqrt(n); i++)
                if (sieve[i] == true)
                    for (int j = i * i; j < n; j += i)
                        sieve[j] = false;

            return sieve;
        }

        /// <summary>
        /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
        /// </summary>
        /// <returns>Long.</returns>
        public static long Problem8()
        {
            string n = "73167176531330624919225119674426574742355349194934" +
                        "96983520312774506326239578318016984801869478851843" +
                        "85861560789112949495459501737958331952853208805511" +
                        "12540698747158523863050715693290963295227443043557" +
                        "66896648950445244523161731856403098711121722383113" +
                        "62229893423380308135336276614282806444486645238749" +
                        "30358907296290491560440772390713810515859307960866" +
                        "70172427121883998797908792274921901699720888093776" +
                        "65727333001053367881220235421809751254540594752243" +
                        "52584907711670556013604839586446706324415722155397" +
                        "53697817977846174064955149290862569321978468622482" +
                        "83972241375657056057490261407972968652414535100474" +
                        "82166370484403199890008895243450658541227588666881" +
                        "16427171479924442928230863465674813919123162824586" +
                        "17866458359124566529476545682848912883142607690042" +
                        "24219022671055626321111109370544217506941658960408" +
                        "07198403850962455444362981230987879927244284909188" +
                        "84580156166097919133875499200524063689912560717606" +
                        "05886116467109405077541002256983155200055935729725" +
                        "71636269561882670428252483600823257530420752963450";
            long max_product = 0;

            for (int i = 0; i < n.Length - 13; i++)
            {
                long p = 1;
                string s = n.Substring(i, 13);
                foreach (char c in s)
                    p *= int.Parse(c.ToString());
                max_product = p > max_product ? p : max_product;
            }

            return max_product;
        }

        /// <summary>
        /// There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
        /// </summary>
        /// <returns>Long.</returns>
        public static long Problem9()
        {
            int sum = 1000;
            for (int a = 1; a < sum / 3; a++)
            {
                for (int b = a + 1; b < sum / 2; b++)
                {
                    var c = 1000 - a - b;
                    if (a * a + b * b == c * c)
                        return a * b * c;
                }
            }
            return 0;
        }

        /// <summary>
        /// Find the sum of all the primes below two million.
        /// </summary>
        /// <returns></returns>
        public static long Problem10()
        {
            long sum = 0;
            int max = 2000000;
            var sieve = SieveOfEratosthenes(max);

            for (int i = 2; i < max; i++)
                if (sieve[i] == true)
                    sum += i;

            return sum;
        }

        //
        public static long Problem11()
        {

        }


    }
}
