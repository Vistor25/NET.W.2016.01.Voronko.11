using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Queue<T> : IEnumerable<T>
    {
        private static readonly int INITIAL_SIZE = 10;
        private T[] array;
        public int count;

        public Queue()
        {
            array = new T[INITIAL_SIZE];
        }

        public Queue(int size)
        {
            array=new T[size];
        }
        public Queue(IEnumerable<T> collection)
        {
            foreach(var element in collection)
            {
                Enqueue(element);
            }
        }
        /// <summary>
        /// Adds the element into the last position of the queue
        /// </summary>
        /// <param name="element">Element that we add</param>
        public void Enqueue(T element)
        {
            CheckSize();
            array[count++] = element;
        }
        /// <summary>
        /// Deletes the last element in the queue
        /// </summary>
        /// <returns>the deleted element</returns>
        public T Dequeue()
        {
            T result = array[0];
            Copy(0);
            count--;
            return result;
        }
        /// <summary>
        /// Peeks the first element of the queue
        /// </summary>
        /// <returns>Peeked element</returns>
        public T Peek()
        {
            return array[0];
        }
        private void Copy(int from)
        {
            for (int i = from; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
        private void CheckSize()
        {
            if (array.Length == count)
            {
                Array.Resize(ref array, (int)(array.Length*1.5));
            }
        }
        class Enumerator<T> : IEnumerator<T>
        {
            private readonly Queue<T> _queue;
            private int _index;

            public Enumerator(Queue<T> queue)
            {
                _queue = queue;
                _index = -1;
            }
            public T Current
            {
                get
                {
                    if (_index == -1 || _index == _queue.count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    return _queue.array[_index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _queue.count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
