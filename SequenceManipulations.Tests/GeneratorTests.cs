using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace SequenceManipulations.Tests
{
    public class GeneratorTests
    {
        [Test]
        public void GenerateFibonacciSequence_LimitIs3_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GenerateFibonacciSequence(3);
            int[] arrayExpected = new int[] { 0, 1, 1 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateFibonacciSequence_LimitIs6_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GenerateFibonacciSequence(3);
            int[] arrayExpected = new int[] { 0, 1, 1, 2, 3, 5 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateFibonacciSequence_LimitIs10_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GenerateFibonacciSequence(3);
            int[] arrayExpected = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateFibonacciSequence_LimitIs16_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GenerateFibonacciSequence(3);
            int[] arrayExpected = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateFibonacciSequence_LimitLessThanZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Generator.GenerateFibonacciSequence(-3));
        }

        [Test]
        public void GeneratePrimeSequence_LimitIs10_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GeneratePrimeSequence(10);
            int[] arrayExpected = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GeneratePrimeSequence_LimitLessThanZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Generator.GeneratePrimeSequence(-3));
        }

        [Test]
        public void GeneratePrimeSequence_LimitIs7_Sequence()
        {
            bool expected = true;
            bool actual = true;
            IEnumerable<BigInteger> arrayActual = Generator.GeneratePrimeSequence(7);
            int[] arrayExpected = new int[] { 1, 3, 5, 7, 9, 11, 13 };
            int i = 0;
            foreach (var number in arrayActual)
            {
                if (BigInteger.Compare(number, arrayExpected[i]) != 0)
                {
                    actual = false;
                }

                i++;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
