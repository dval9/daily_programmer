using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problems
{
    /// <summary>
    ///  This class contains a collection of solved problems from https://old.reddit.com/r/dailyprogrammer.
    ///  These are the problems marked as difficulty level 'easy'.
    /// </summary>
    public class EasyProblems
    {
        /// <summary>
        /// A subfactorial is a derangement of a set of n objects, such that no element appears in its original position. It is written !n.
        /// </summary>
        /// <param name="n">Long, size of the set.</param>
        /// <returns>Long with the value of !n</returns>
        public static long Subfactorials_367(long n)
        {
            Dictionary<long, long> lookup = new Dictionary<long, long>
            {
                { 1, 0 },
                { 2, 1 }
            };

            for (int i = 3; i <= n; i++)
                lookup.Add(i, (i - 1) * (lookup[i - 1] + lookup[i - 2]));
            
            return lookup[n];
        }

        /// <summary>
        ///  Determine if the second word can be made from the first by removing one letter
        /// </summary>
        /// <param name="f">First string.</param>
        /// <param name="s">Second string to compare to.</param>
        /// <returns>True if string 's' can written by removing 1 letter from string 'f', otherwise False</returns>
        public static bool Funnel_366(string f, string s)
        {
            for (int i = 0; i < f.Length; i++)
            {
                if (f.Remove(i, 1).Equals(s))
                    return true;
            }
            return false;
        }
    }
}
