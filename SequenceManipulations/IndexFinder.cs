using System;
using System.Collections.Generic;

namespace SequenceManipulations
{
    /// <summary>
    /// IndexFinder class
    /// </summary>
    public class IndexFinder
    {
        /// <summary>
        /// Find element in sequence using binary search algorithm
        /// </summary>
        /// <typeparam name="T">type name</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>index of input key in array</returns>
        /// <exception cref="System.ArgumentNullException">Occurs if input array is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Occurs if input array is empty
        /// or
        /// input values are invalid
        /// </exception>
        public static int BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Input array is null!", nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Input array is empty!", nameof(array));

            }

            if (comparer == null)
            {
                if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                {
                    comparer = Comparer<T>.Default;
                }

                if (comparer == null)
                {
                    throw new InvalidOperationException("Default comparer is not found.");
                }
            }

            int left = 0;
            int right = array.Length - 1;
            while (left.CompareTo(right) <= 0)
            {
                var middle = (left + right) / 2;

                if (comparer.Compare(key, array[middle]) == 0)
                {
                    return middle;
                }
                else if (comparer.Compare(key, array[middle]) < 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            throw new ArgumentException("Invalid array!", nameof(array));
        }
    }
}
