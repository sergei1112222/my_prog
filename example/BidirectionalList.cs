using System;
using System.Collections;
using System.Collections.Generic;

namespace Structure
{
    public class Bidirectionallist<T> : IEnumerable<T>
    {


        Element<T> _head;
        Element<T> _tail;
        int _сount;
        public class Element<T>
        {

            public T Data { get; set; }
            public Element<T> Previous { get; set; }
            public Element<T> Next { get; set; }
            public Element(T data)
            {
                this.Data = data;
            }
            public Element(Element<T> elem)
            {
                Data = elem.Data;
                Previous = elem.Previous;
                Next = elem.Next;
            }
        }

        public Bidirectionallist (Bidirectionallist<T> list)
        {
            Element<T> pointer = list._tail;
            while (pointer != null)
            {
                this.PushHead(pointer.Data);
                pointer = pointer.Next;
            }
        }
        public Bidirectionallist() { }
        public void PushHead(T data)
        {
            Element<T> el = new Element<T>(data);
            if (_head == null) { _head = el; }
            else
            {
                _tail.Previous = el;
				el.Next = _tail;
            }
            _tail = el;
			_сount++;
        }

        public void PushTail(T data)
        {
            Element<T> el = new Element<T>(data);
            if (_tail == null) { _tail = el; }
            else
            {
                _head.Next = el;
				el.Previous = _head;
            }
            _head = el;
			_сount++;
        }

        public bool PushInsert(int index, T data)
        {
            Element<T> el = new Element<T>(data);
            int resultIndex;
            string strIndex = index.ToString();
            bool isConvert = int.TryParse(strIndex, out resultIndex);
            if (isConvert && ((resultIndex >= 0) && (resultIndex <= _сount)))
            {
                int counter = 0;
                Element<T> Pointer = _tail;
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

        public void PrintList()
        {
            Element<T> pointer = _tail;
            int counter = 0;
            while (pointer != null)
            {
                Console.WriteLine("[" + counter.ToString() + "] = " + pointer.Data);
                counter++;
                pointer = pointer.Next;
            }
        }

        public T FindElementInd(int index)
        {
            Element<T> pointer = _tail;
            Element<T> findElement = null;
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

        public int FindElement(T Data)
        {
            Element<T> pointer = _tail;
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

        /*public int SelectIndexElement(string selectRequest)
        {
            int returnedIndex = -1;
            int counter = 0;
            Element<T> pointer = _tail;
            string[] requestPart = selectRequest.Split(' ');
            T comparator;
            //T.TryParse(requestPart[1], out comparator);
            switch (requestPart[0])
            {
                case "<": 
                {
                    bool flag = false;
                    while ((!flag) && (pointer != null))
                    {

                        if (pointer.Data < comparator)
                        {
								returnedIndex = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
                case ">":
                {
                    bool flag = false;
                    while ((!flag) && (pointer != null))
                    {

                        if (pointer.Data > comparator)
                        {
								returnedIndex = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
                case "<=":
                {
                    bool flag = false;
                    while ((!flag) && (pointer != null))
                    {

                        if (pointer.Data <= comparator)
                        {
								returnedIndex = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
                case ">=":
                {
                    bool flag = false;
                    while ((!flag) && (pointer != null))
                    {

                        if (pointer.Data < comparator)
                        {
								returnedIndex = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
                case "=":
                {
                    bool flag = false;
                    while ((!flag) && (pointer != null))
                    {

                        if (pointer.Data == comparator)
                        {
								returnedIndex = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
            }
            return returnedIndex;
        }*/

        public bool Remove(int index)
        {
            string strIndex = index.ToString();
            bool isRemove = false;
            if (_сount >= 1)
            {
                int counter = 0;
                
                Element<T> pointer = _tail;
                int resultIndex = -1;
                bool isConvert = int.TryParse(strIndex, out resultIndex);
                if (isConvert && ((resultIndex >= 0) && (resultIndex < _сount)))
                {
                    bool flag = false;
                    while (!flag)
                    {
                        if (counter == resultIndex)
                        {
                            if ((pointer.Next != null) && (pointer.Previous != null))
                            {
                                pointer.Next.Previous = pointer.Previous;
                                pointer.Previous.Next = pointer.Next;
                            }
                            if (pointer.Next == null)
                            {
								_head = pointer.Previous;
								_head = null;
                            }
                            if (pointer.Previous == null)
                            {
								_tail = pointer.Next;
								_tail.Previous = null;
                            }
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
            
            return Remove(this.FindElement(Data));
        }

        /*public bool RemoveSelect(string selectRequest){
            return Remove(this.SelectIndexElement(selectRequest));
        }*/
        /*IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }*/
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Element<T> pointer = _tail;
            int counter = 0; 
            while (pointer != null)
            {
                yield return pointer.Data;
                counter++;
                pointer = pointer.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Element<T> pointer = _tail;
            int counter = 0;
            while (pointer != null)
            {
                yield return pointer.Data;
                counter++;
                pointer = pointer.Next;
            }
        }
    }

    
    

}