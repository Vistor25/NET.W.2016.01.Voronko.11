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
        private int head;
        private int tail;
        public int count;

        public Queue()
        {
            array = new T[INITIAL_SIZE];
        }

        public Queue(int size)
        {
            array=new T[size];
        }
        public void Enqueue(T element)
        {
            CheckSize();
            array[tail++] = element;
            count++;
            if (tail == array.Length) tail = 0;
        }

        public T Dequeue()
        {
            T result = array[head++];
            count--;
            if (head == array.Length) head = 0;
            return result;
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
