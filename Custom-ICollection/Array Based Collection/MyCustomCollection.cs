using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_ICollection.Array_Based_Collection
{
    public class MyCustomCollection<T> : ICollection<T>
    {
        private T[] _Elements = new T[1];


        private int _Count;

        /// <summary>
        /// Returns the number of elements currently in the collection.
        /// </summary>
        public int Count => _Count;

        /// <summary>
        /// Indicates whether the collection is read-only. Always false for this collection.
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// Adds a new element to the collection.
        /// If the internal array is full, it resizes it first.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Add(T element)
        {
            if (_Count == _Elements.Length)
                Resize(_Elements.Length * 2);

            _Elements[_Count++] = element;
        }

        public bool AddUnique(T element)
        {
            if (_Elements.Contains(element))
                return false;

            Add(element);
            return true;
        }
        /// <summary>
        /// Resizes the internal array to a new size and copies existing elements.
        /// </summary>
        /// <param name="newSize">The new size of the internal array.</param>
        public void Resize(int newSize)
        {
            T[] newArr = new T[newSize];

            Array.Copy(_Elements, newArr, _Count);

            _Elements = newArr;
        }

        /// <summary>
        /// Removes the first occurrence of the specified element.
        /// Shifts remaining elements to the left to fill the gap.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        /// <returns>True if the element was found and removed; otherwise, false.</returns>
        public Boolean Remove(T element)
        {
            //Find The Element Index
            int indexOf = Array.IndexOf(_Elements, element, 0, _Count);

            //Check Of Index Is Valid
            if (indexOf < 0)
                return false;

            //Start With Reoving Element Index
            for (int i = indexOf; i < _Count - 1; i++)
            {
                // Shift all elements after the removed element one position to the left
                // This prevents leaving a Gap in the array 
                _Elements[i] = _Elements[i + 1];
            }


            _Elements[--_Count] = default;

            return true;
        }


        /// <summary>
        /// Prints all elements in the internal array, including default values.
        /// Mainly for testing purposes to see what remains after Clear.
        /// </summary>
        public void PrintAfterClear()
        {

            // I added this method just for testing: 
            // To see what happens if we iterate through _Elements using Length instead of _Count
            // After calling Clear(), the array elements might be default(T) or the array may be empty,
            // depending on which Clear implementation i use.
            for (int i = 0; i < _Elements.Length; i++)
                Console.WriteLine(_Elements[i]);
        }

        /// <summary>
        /// Clears the collection.
        /// Can either set each element to default(T) (keeping capacity) 
        /// or replace the array with a new empty array (capacity becomes 0).
        /// </summary>
        public void Clear()
        {
            // This is O(n): sets each element to default(T)
            // Advantage: keeps the old array capacity, so adding new elements
            // later may not require resizing immediately.

            for (int i = 0; i < _Elements.Length; i++)
            {
                _Elements[i] = default;
            }

            // This is O(1): replaces the array with a new empty array
            // Advantage: clears all elements immediately and frees the old array for GC
            // Disadvantage: the array capacity becomes 0, so adding a new element
            // will force a resize of the array.

            //_Elements = new T[0];
            //_Count = 0;
        }
        /// <summary>
        /// Copies the elements of the collection to a specified array starting at the given index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The zero-based index in the destination array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_Elements, 0, array, arrayIndex, _Count);
        }

        /// <summary>
        /// Determines whether the collection contains a specific element.
        /// </summary>
        /// <param name="element">The element to locate in the collection.</param>
        /// <returns>True if the element is found; otherwise, false.</returns>
        public bool Contains(T element)
        {
            return _Elements.Contains(element);
        }
        /// <summary>
        /// Sorts the elements in descending order.
        /// Only the valid elements (0.._Count-1) are sorted.
        /// </summary>
        public void SortDescending()
        {
            var sortDESC = _Elements.Take(_Count).OrderByDescending(e => e).ToArray(); ;

            for (int i = 0; i < Count; i++)
                _Elements[i] = sortDESC[i];
        }
        /// <summary>
        /// Sorts the elements in ascending order.
        /// Only the valid elements (0.._Count-1) are sorted; default(T) values after _Count remain untouched.
        /// </summary>
        public void Sort()
        {
            var sorted = _Elements.Take(_Count).OrderBy(e => e);
            int i = 0;
            foreach (T element in sorted)
            {
                _Elements[i++] = element;
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            int n = _Count;

            while (n > 0)
            {
                n--;
                int next = rand.Next(n);
                var temp = _Elements[next];
                _Elements[next] = _Elements[n];
                _Elements[n] = temp;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {

            //If i use Length it will print even the default values 
            for (int i = 0; i < _Count; i++)
            {
                yield return _Elements[i];
            }
        }
        /// <summary>
        /// Returns a non-generic enumerator that iterates through the collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
