//СРЕДНИЙ УРОВЕНЬ 12 ЗАДАНИЕ 
//НАЗАРОВ РУСЛАН 
//23-ИСП-2/1

//lab8

namespace lab6789_nazarov
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedList
    {
        private ListNode _head;
        public ListNode Head => _head;

        public void Add(int value)
        {
            var newNode = new ListNode(value);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public int SumOfValuesGreaterOrEqualTo(int threshold)
        {
            var sum = 0;
            var current = _head;
            while (current != null)
            {
                if (current.Value >= threshold)
                {
                    sum += current.Value;
                }

                current = current.Next;
            }

            return sum;
        }

        public void RemoveValuesLessThan(int threshold)
        {
            ListNode prev = null;
            var current = _head;
            while (current != null)
            {
                if (current.Value < threshold)
                {
                    if (prev == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                }
                else
                {
                    prev = current;
                }
                current = current.Next;
            }
        }
    }
}