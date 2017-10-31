using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _count;

        public GenericList()
        {
            _internalStorage = new X[4];
            _count = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("List can't be resolved. Size can't be negative.");
            }
            else
            {
                _internalStorage = new X[initialSize];
                _count = 0;
            }
        }


        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(X item)
        {
            if ((_count + 1) > _internalStorage.Length)
            {
                X[] temp = new X[_internalStorage.Length * 2];
                Array.Copy(_internalStorage, temp, _internalStorage.Length);
                _internalStorage = temp;
            }
            _internalStorage[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(X item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                return true;
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            return RemoveAt(index);

        }

        public bool RemoveAt(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < (_count - 1); i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> genericList;
        private T _current;

        private int position = -1;

        public GenericListEnumerator(GenericList<T> genericList)
        {
            this.genericList = genericList;
            _current = genericList.GetElement(0);
        }

        public T Current
        {
            get
            {
                try
                {
                    return genericList.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }


        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            position++;
            return position < genericList.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
