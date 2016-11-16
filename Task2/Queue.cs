using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;
        public int count;

        public Queue()
        {
            array = new T[0];
        }

        public void Enqueue(T element)
        {
            CheckSize();
            array[count++] = element;
        }

        public T Dequeue()
        {
            T result = array[0];
            Copy(0);
            count--;
            return result;
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
            private Queue<T> _queue;
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
                throw new NotImplementedException();
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
