using System;
using System.Collections;
using System.Collections.Generic;

namespace Structure
{
    public class Bidirectionallist<T> : IEnumerable<T>
    {
        public delegate bool MyPredicate(T el);
        private class Element
        {
            public T Data { get; set; }
            public Element Previous { get; set; }
            public Element Next { get; set; }

            public Element(T data)
            {
                this.Data = data;
            }
            public Element(Element elem)
            {
                Data = elem.Data;
                Previous = elem.Previous;
                Next = elem.Next;
            }
        }
        Element _head;
        Element _tail;
        int _сount;

        public Bidirectionallist() { }

        public Bidirectionallist (Bidirectionallist<T> list)
        {
            Element pointer = list._head;
            while (pointer != null)
            {
                this.PushTail(pointer.Data);
                pointer = pointer.Next;
            }
        }

        public int Count
        {
            get { return this._сount; }
        }
        public void PushTail(T data)
        {
            Element el = new Element(data);
            if (_head == null) { _head = el; }
            else
            {
                _tail.Next = el;
				el.Previous = _tail;
            }
            _tail = el;
			_сount++;
        }

        public void PushHead(T data)
        {
            Element el = new Element(data);
            if (_tail == null) { _tail = el; }
            else
            {
                _head.Previous = el;
				el.Next = _head;
            }
            _head = el;
			_сount++;
        }

        public bool PushInsert(int index, T data)
        {
            Element el = new Element(data);
            int resultIndex;
            string strIndex = index.ToString();
            bool isConvert = int.TryParse(strIndex, out resultIndex);
            if (isConvert && ((resultIndex >= 0) && (resultIndex <= _сount)))
            {
                int counter = 0;
                Element Pointer = _head;
                while (counter < resultIndex)
                {
                    if (counter == resultIndex - 1)
                    {
                        if (Pointer.Previous == null)
                            PushTail(el.Data);
                        else
                            if (Pointer.Next == null)
                            PushHead(el.Data);
                        else
                        {
                            el.Previous = Pointer.Previous;
                            el.Next = Pointer;
                            Pointer.Previous = el;
                            _сount++;
                        }
                    }
                    Pointer = Pointer.Next;
                    counter++;
                }
                return true;
            }
            else
                return false;
        }

        public T FindElementInd(int index)
        {
            Element pointer = _head;
            Element findElement = null;
            int counter = 0;
            int resIndex;
            string strIndex = index.ToString();
            bool isConvert = int.TryParse(strIndex, out resIndex);
            if (isConvert && ((resIndex >= 0) && (resIndex < _сount)))
            {
                while (counter <= resIndex)
                {
                    if (counter == resIndex)
                    {
						findElement = pointer;
                    }
                    counter++;
                    pointer = pointer.Next;
                    
                }

            }
            else
				findElement = null;
            return findElement.Data;
        }
        
        public bool RemoveRequest(MyPredicate p, bool removeOption)
        {
            bool isRemove = false;
            bool flagRemove;
            Element pointer = _head;
            if (removeOption)
                flagRemove = pointer != null;
            else
                flagRemove = (pointer != null) && (!isRemove);
            while ((pointer != null) && (!isRemove))
            {
                if (p(pointer.Data))
                {
                    this.RemoveOperation(pointer);
                    isRemove = true;
                }
                pointer = pointer.Next;
            }
            return isRemove;
        }

        public int FindElement(T Data)
        {
            Element pointer = _head;
            int counter = 0;
            int returnIndex = -1;
            while (pointer != null)
            {
                if (pointer.Data.Equals(Data))
					returnIndex = counter;
                counter++;
                pointer = pointer.Next;
            }

            return returnIndex;
        }

        public bool Remove(int index)
        {
            string strIndex = index.ToString();
            bool isRemove = false;
            if (_сount >= 1)
            {
                int counter = 0;
                
                Element pointer = _head;
                int resultIndex = -1;
                bool isConvert = int.TryParse(strIndex, out resultIndex);
                if (isConvert && ((resultIndex >= 0) && (resultIndex < _сount)))
                {
                    bool flag = false;
                    while (!flag)
                    {
                        if (counter == resultIndex)
                        {
                            RemoveOperation(pointer);
							_сount--;
                            flag = true;
							isRemove = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                }
                else
					isRemove = false;
            }
            else
				isRemove = false;

            return isRemove;
        }
 
        public bool RemoveValue(T Data)
        {
            bool isRemove = false;
            Element pointer = _head;
            while ((pointer != null) && (!isRemove))
            {
                if (pointer.Data.Equals(Data))
                {
                    RemoveOperation(pointer);
                    isRemove = true;
                }
                pointer = pointer.Next;
            }
            return isRemove;
        }

        private IEnumerator<T> ReturnNumerable()
        {
            Element pointer = _head;
            int counter = 0;
            while (pointer != null)
            {
                yield return pointer.Data;
                counter++;
                pointer = pointer.Next;
            }
        }

        private void RemoveOperation(Element pointer)
        {
            if ((pointer.Next == null) && (pointer.Previous == null))
            {
                _head = null;
                _tail = null;
            }
            else
            {
                if ((pointer.Next != null) && (pointer.Previous != null))
                {
                    pointer.Next.Previous = pointer.Previous;
                    pointer.Previous.Next = pointer.Next;
                }
                else
                {
                    if (pointer.Next == null)
                    {
                        _tail = pointer.Previous;
                        _tail.Next = null;
                    }
                    if (pointer.Previous == null)
                    {
                        _head = pointer.Next;
                        _head.Previous = null;
                    }
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ReturnNumerable();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ReturnNumerable();
        }
    }

    
    

}