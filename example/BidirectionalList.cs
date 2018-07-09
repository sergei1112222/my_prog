using System;

namespace ACme.Collections
{
    
    public class BidirectionalList
    {
        private element head;
        private element tail;
        private int count;
        public BidirectionalList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public void push_tail(element _el)
        {
            if (this.head == null)
            {
                this.head = _el;
            }
            else
            {
                this.tail.Previous = _el;
                _el.Next = this.tail;
            }
            this.tail = _el;
            this.count++;
        }
        public void push_head(element _el)
        {
            if (tail == null)
            {
                this.tail = _el;
            }
            else
            {
                this.head.Next = _el;
                _el.Previous = this.head;
            }
            this.head = _el;
            this.count++;
        }
        public bool push_insert(string index, element _el)
        {
            int result_index;
            bool is_convert = int.TryParse(index, out result_index);
            if (is_convert && ((result_index >= 0) && (result_index <= this.count)))
            {
                int local_counter = 0;
                element elem_Pointer = tail;
                while (local_counter < result_index)
                {
                    if (local_counter == result_index-1)
                    {
                        if (elem_Pointer.Previous == null)
                            push_tail(_el);
                        else
                            if (elem_Pointer.Next == null)
                                push_head(_el);
                            else
                            {
                                _el.Previous = elem_Pointer.Previous;
                                _el.Next = elem_Pointer;
                                elem_Pointer.Previous = _el;
                                this.count++;
                            }
                    }
                    elem_Pointer = elem_Pointer.Next;
                    //Console.WriteLine(elem_Pointer.Data);
                    local_counter++;
                }
                return true;
            }
            else
                return false;
        }
        public void printList()
        {
            element pointer = this.tail;
            int counter = 0;
            while (pointer != null)
            {
                Console.WriteLine("[" + counter.ToString() + "] = " + pointer.Data.ToString());
                counter++;
                pointer = pointer.Next;
            }
        }
        public element find_element(string index)
        {
            element pointer = this.tail;
            element result_element = null;
            int counter = 0;
            int result_index;
            bool is_convert = int.TryParse(index, out result_index);
            if (is_convert && ((result_index >= 0) && (result_index < this.count)))
            {
                while (counter <= result_index)
                {
                    if (counter == result_index)
                    {
                        result_element = pointer;
                    }
                    counter++;
                    pointer = pointer.Next;
                    
                }

            }
            else
                result_element = null;
            return result_element;
        }
        public int find_element(element _el)
        {
            element pointer = this.tail;
            int counter = 0;
            int returned_index = -1;
            while (pointer != null)
            {
                if (pointer.Data == _el.Data)
                    returned_index = counter;
                counter++;
                pointer = pointer.Next;
            }
            return returned_index;
        }
        public int selectIndexelement(string select_request)
        {
            int returned_index = -1;
            int counter = 0;
            element pointer = this.tail;
            string[] requestPart = select_request.Split(' ');
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
                            returned_index = counter;
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
                            returned_index = counter;
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
                            returned_index = counter;
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
                            returned_index = counter;
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
                            returned_index = counter;
                            flag = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                    break;
                }
            }
            return returned_index;
        }
        public bool remove(string index)
        {
            bool is_remove = false;
            if (this.count >= 1)
            {
                int counter = 0;
                
                element pointer = this.tail;
                int result_index = -1;
                bool is_convert = int.TryParse(index, out result_index);
                if (is_convert && ((result_index >= 0) && (result_index < this.count)))
                {
                    bool flag = false;
                    while (!flag)
                    {
                        if (counter == result_index)
                        {
                            if ((pointer.Next != null) && (pointer.Previous != null))
                            {
                                pointer.Next.Previous = pointer.Previous;
                                pointer.Previous.Next = pointer.Next;
                            }
                            if (pointer.Next == null)
                            {
                                head = pointer.Previous;
                                head.Next = null;
                            }
                            if (pointer.Previous == null)
                            {
                                tail = pointer.Next;
                                tail.Previous = null;
                            }
                            this.count--;
                            flag = true;
                            is_remove = true;
                        }
                        counter++;
                        pointer = pointer.Next;
                    }
                }
                else
                    is_remove = false;
            }
            else
                is_remove = false;

            return is_remove;
        }
        public bool remove_value(element _el)
        {
            return remove(this.find_element(_el).ToString());
        }
        public bool remove_select(string select_request){
            return remove(this.selectIndexelement(select_request).ToString());
        }
    }
    public class element
    {
        private int data;
        private element next;
        private element previous;
        public int Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public element Previous
        {
            get {return previous; }
            set { previous = value; }
        }
        public element Next
        {
            get { return next; }
            set { next = value; }
        }
        public element(int data) 
        {
            this.data = data;
            this.Next = null;
            this.Previous = null;
        }
    }
    

}