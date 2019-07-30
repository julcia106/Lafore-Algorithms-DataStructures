//5.1 Implement a priority queue based on a sorted linked list.The remove operation
//on the priority queue should remove the item with the smallest key.

using System;

namespace Queue
{
    class Link
    {
        public long data;
        public Link next;

        public Link(long d)
        {
            data = d;
        }

        public void displayLink()
        {
            Console.Write(data + " ");
        }
    }
    class PriorityQueue
    {
        private Link first;
        private Link last;

        public PriorityQueue()
        {
            first = null;
            last = null;
        }

        public bool isEmpty()=> first==null;

        public void insert(long value)
        {
            Link newLink = new Link(value);
            Link prev = null;
            Link curr = first;

            while (curr != null && value > curr.data) 
            {
                prev = curr;
                curr = curr.next;
            }

            if (prev == null)
            {
                first = newLink;
            }
            else
                prev.next = newLink;
            newLink.next = curr;
        }

        public void deleteFirst()
        {
            if (first.next == null)
            {
                last = null;
            }
            else
                first = first.next;

        }
        public void display()
        {
            Link current = first;
            Console.Write("first --> ");
            while (current != null)
            {
                current.displayLink();
                current = current.next;
            }
            Console.Write(" --> last");
            Console.WriteLine();
        }
    }

    class PriorityQueueApp
    {
        static void Main(string[] args)
        {
            PriorityQueue one = new PriorityQueue();

            one.insert(2);
            one.insert(12);
            one.insert(22);
            one.insert(52);
            one.display();

            one.deleteFirst();
            one.display();
        }
    }
}
