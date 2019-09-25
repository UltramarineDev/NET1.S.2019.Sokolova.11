using System;
using NUnit.Framework;


namespace SequenceManipulations.Tests
{
    class IndexFinderTests
    {
        [Test]
        public void IndexFinder_StringArray_Index()
        {
            string[] array = new string[] { "45", "top", "dfr", "pop", "seq" };
            string key = "dfr";
            int actual = IndexFinder.BinarySearch<string>(array, key,null);
            int expected = 2;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void IndexFinder_IntArray_Index()
        {
            int[] array = new int[] { -9, 6, 45, 78, 495687};
            int key = 78;
            int actual = IndexFinder.BinarySearch<int>(array, key,null);
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void IndexFinder_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IndexFinder.BinarySearch<int>(new int[] { }, 5,null));
        }

        [Test]
        public void IndexFinder_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => IndexFinder.BinarySearch<int>(null, 5,null));
        }

        [Test]
        public void IndexFinder_InvalidKey_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IndexFinder.BinarySearch<int>(new int[] { 5, 67, 65, 123}, 0,null));
        }

        [Test]
        public void IndexFinder_UnsortedArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => IndexFinder.BinarySearch<int>(new int[] { 5, 67, -5, 123 }, 0,null));
        }
    }
}
