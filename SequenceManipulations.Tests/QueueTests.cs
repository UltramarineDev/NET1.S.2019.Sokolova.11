using System;
using NUnit.Framework;

namespace SequenceManipulations.Tests
{
    class QueueTests
    {
        [Test]
        public void Enqueue_EnqueueElement_QueueOfInt()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(0);

            int[] actual = queue.ToArray();
            int[] expected = { 0, 10, 5 };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dequeue_DequeueElement_QueueOfString()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("array");
            queue.Enqueue("date");
            queue.Enqueue("one");
            queue.Dequeue();

            string[] actual = queue.ToArray();
            string[] expected = { "one", "date" };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dequeue_ArrayIsEmpty_ThrowInvalidOperationException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Contains_IntegerKey_True()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(0);

            Assert.AreEqual(true, queue.Contains(0));
        }

        [Test]
        public void Contains_IntegerKey_False()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(0);

            Assert.AreEqual(false, queue.Contains(-678));
        }

        [Test]
        public void Peek_QueueofStrings_FirstItem()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("array");
            queue.Enqueue("date");
            queue.Enqueue("one");
           
            Assert.AreEqual("array", queue.Peek());
        }

        [Test]
        public void Peek_ArrayIsEmpty_ThrowInvalidOperationException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Queue_CapacityLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<int>(-8));
        }
    }
}
