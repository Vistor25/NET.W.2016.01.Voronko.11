using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task3
{
    public class Set<T> : IEnumerable<T> where T : class
    {
        private static readonly int INITIAL_SIZE = 10;
        private T[] array;
        public int count;

        public Set()
        {
            array = new T[INITIAL_SIZE];
        }

        public Set(int size)
        {
            array = new T[size];
        }

        private void CheckSize()
        {
            if (array.Length == count)
            {
                Array.Resize(ref array, (int) (array.Length*1.5));
            }
        }
        private void Copy(int from)
        {
            for (int i = from; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
        /// <summary>
        /// Adds an item into the set
        /// </summary>
        /// <param name="item">item that we add</param>
        public void Add(T item)
        {
            foreach (var element in array)
            {
                if (item.Equals(element)) throw new ArgumentException("Already exists");
             }
            array[count++] = item;
        }
        /// <summary>
        /// Deletes the item from the set
        /// </summary>
        /// <param name="item">Item that we want to delete</param>
        public void Remove(T item)
        {
            int index = 0;
            foreach (var element in array)
            {
                index++;
                if (element.Equals(item))
                {
                    Copy(index);
                }
            }
            count--;
        }
        /// <summary>
        /// Approves or disapproves that item exists in the set
        /// </summary>
        /// <param name="item">item we want to check existense</param>
        /// <returns>true or false</returns>
        public bool Contains(T item)
        {
            if (array.Contains(item)) return true;
            return false;
        }
        /// <summary>
        /// Unions one set with another
        /// </summary>
        /// <param name="otherSet">set we union with</param>
        /// <returns>Unioned set</returns>
        public Set<T> Union(Set<T> otherSet)
        {
            
            foreach (var element in otherSet)
            {
                if(!Contains(element)) Add(element);
            }
            return this;
        }
        /// <summary>
        /// Intersects one set with another
        /// </summary>
        /// <param name="otherSet">set we intersect with</param>
        /// <returns>Intersected set</returns>
        public Set<T> Intersection(Set<T> otherSet)
        {
            foreach (var element in this)
            {
                if (!otherSet.Contains(element)) Remove(element);
            }
            return this;
        }
        /// <summary>
        /// Differences one set with another
        /// </summary>
        /// <param name="otherSet">set we difference with</param>
        /// <returns>Differenced set</returns>
        public Set<T> Difference(Set<T> otherSet)
        {
            foreach (var element in this)
            {
                if (otherSet.Contains(element)) Remove(element);
            }
            return this;
        }
        /// <summary>
        /// Symmetric differences one set with another
        /// </summary>
        /// <param name="otherSet">set we difference with</param>
        /// <returns></returns>
        public Set<T> SymmetricDifference(Set<T> otherSet)
        {
            Set<T> union = Union(otherSet);
            Set<T> intersection = Intersection(otherSet);
            return union.Difference(intersection);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in array)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
