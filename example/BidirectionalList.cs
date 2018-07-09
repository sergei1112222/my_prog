using System;

namespace Smarteck.Structure
{
    
    public class Bidirectionallist
    {
        public class Element
        {
            int _data;
            Element _next;
            Element _previous;

            public int Data { get; set; }
            public Element Previous { get; set; }
            public Element Next { get; set; }
            public Element(int data)
            {
                this._data = data;
            }
        }
        Element _head;
        Element _tail;
        int _сount;

        public Bidirectionallist()
        {
            _head = null;
            _tail = null;
			_сount = 0;
        }

        public void PushTail(Element el)
        {
            if (_head == null) { _head = el; }
            else
            {
                _tail.Previous = el;
				el.Next = _tail;
            }
            _tail = el;
			_сount++;
        }

        public void PushHead(Element el)
        {
            if (_tail == null) { _tail = el; }
            else
            {
                _head.Next = el;
				el.Previous = _head;
            }
            _head = el;
			_сount++;
        }

        public bool PushInsert(string index, Element el)
        {
            int resultIndex;
            bool isConvert = int.TryParse(index, out resultIndex);
            if (isConvert && ((resultIndex >= 0) && (resultIndex <= _сount)))
            {
                int counter = 0;
                Element Pointer = _tail;
                while (counter < resultIndex)
                {
                    if (counter == resultIndex - 1)
                    {
                        if (Pointer.Previous == null)
							PushTail(el);
                        else
                            if (Pointer.Next == null)
								PushHead(el);
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

        public void printList()
        {
            Element pointer = _tail;
            int counter = 0;
            while (pointer != null)
            {
                Console.WriteLine("[" + counter.ToString() + "] = " + pointer.Data.ToString());
                counter++;
                pointer = pointer.Next;
            }
        }

        public Element findElement(string index)
        {
            Element pointer = _tail;
            Element findElement = null;
            int counter = 0;
            int resIndex;
            bool isConvert = int.TryParse(index, out resIndex);
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
            return findElement;
        }

        public int findElement(Element el)
        {
            Element pointer = _tail;
            int counter = 0;
            int returnIndex = -1;
            while (pointer != null)
            {
                if (pointer.Data == el.Data)
					returnIndex = counter;
                counter++;
                pointer = pointer.Next;
            }
            return returnIndex;
        }

        public int selectIndexElement(string selectRequest)
        {
            int returnedIndex = -1;
            int counter = 0;
            Element pointer = _tail;
            string[] requestPart = selectRequest.Split(' ');
            int comparator = 0;
            int.TryParse(requestPart[1], out comparator);
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
        }

        public bool remove(string index)
        {
            bool isRemove = false;
            if (_сount >= 1)
            {
                int counter = 0;
                
                Element pointer = _tail;
                int resultIndex = -1;
                bool isConvert = int.TryParse(index, out resultIndex);
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

        public bool removeValue(Element el)
        {
            return remove(this.findElement(el).ToString());
        }

        public bool removeSelect(string selectRequest){
            return remove(this.selectIndexElement(selectRequest).ToString());
        }
    }

    
    

}