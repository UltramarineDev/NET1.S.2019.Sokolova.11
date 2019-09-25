using System;
using System.Collections;
using System.Collections.Generic;

namespace SequenceManipulations
{
    /// <summary>
    /// Queue generic class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;

        private const int defaultCapacity = 10;

        public int Count { get; private set; }
        private int Version { get; set; }

        public Queue()
        {
            this.array = new T[0];
            this.Count = 0;
            this.Version = 0;
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} can not be less or equal zero!");
            }

            array = new T[capacity];
            Count = 0;
            Version = 0;
        }

        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                T[] newArray = new T[(array.Length == 0) ? defaultCapacity : 2 * array.Length];
                Array.Copy(array, 0, newArray, 0, Count);
                array = newArray;
            }

            array[Count++] = item;
            Version++;            
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            Version++;

            T output = array[0];
            for (int i = 0; i < Count; i++)
            {
                array[i] = array[i + 1];
            }

            Count--;
            array[Count] = default(T);

            return output;
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {

            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return array[0];
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Converts queue to array.
        /// </summary>
        /// <returns>array</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            int i = 0;

            while (i < Count)
            {
                newArray[i] = array[Count - i - 1];
                i++;
            }

            return newArray;
        }

        private struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private readonly int version;

            private int index;
            private T currentElement;

            public Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                version = queue.Version;
                index = -2;
                currentElement = default(T);
            }

            public T Current
            {
                get
                {
                    if (index == -2)
                    {
                        throw new InvalidOperationException("Iteration do not started!");
                    }

                    if (index == -1)
                    {
                        throw new InvalidOperationException("Iteration was ended!");
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (version != queue.Version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                bool result;

                if (index == -2)
                {
                    index = queue.Count - 1;
                    result = index >= 0;

                    if (result)
                    {
                        currentElement = queue.array[index];
                    }

                    return result;
                }

                if (index == -1)
                {
                    return false;
                }

                result = --index >= 0;

                currentElement = result ? queue.array[index] : default(T);

                return result;
            }

            public void Reset()
            {
                if (version != queue.Version)
                {
                    throw new InvalidOperationException("Stack was changed!");
                }

                index = -2;

                currentElement = default(T);
            }
        }
    }
}
