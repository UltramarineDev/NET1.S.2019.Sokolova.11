using System.Collections.Generic;
using System.Numerics;
using System;

namespace SequenceManipulations
{
    public static class Generator
    {
        /// <summary>
        /// Generates the fibonacci sequence.
        /// </summary>
        /// <param name="limit">number of elements to be generated</param>
        /// <returns>Fibonacci sequence</returns>
        /// <exception cref="ArgumentException">Invalid number of elements! - limit</exception>
        public static IEnumerable<BigInteger> GenerateFibonacciSequence(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Invalid number of elements!", nameof(limit));
            }

            for (int i = 0; i < limit; i++)
            {
                yield return GenerateFibonacciNumber(i);
            }
        }

        private static BigInteger GenerateFibonacciNumber(int number)
        {
            return number > 1 ? GenerateFibonacciNumber(number - 1) + GenerateFibonacciNumber(number - 2) : number;
        }

        /// <summary>
        /// Generates the prime sequence.
        /// </summary>
        /// <param name="limit">Number of elements to be generated</param>
        /// <returns>Prime sequence</returns>
        /// <exception cref="ArgumentException">Invalid number of elements! - limit</exception>
        public static IEnumerable<BigInteger> GeneratePrimeSequence(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Invalid number of elements!", nameof(limit));
            }

            for (int i = 0, j = 1; i < limit; i++, j+=2)
            {
                yield return j;
            }
        }
    }
}
