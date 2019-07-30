using System;

namespace Queue
{
    class Link
    {
        public long data;
        public Link next;

        public Link(long value)
        {
            data = value;
        }
    }

    class Dequeue
    {
        private Link right;
        private Link left;

        public Dequeue()
        {
            right = null;
            left = null;
        }

        public bool isEmpty() => right == null;
        

        public void insertLeft(long value)
        {
            Link newLink = new Link(value);

            if (isEmpty())
            {
                right = newLink;
            }
            else
                newLink.next = left;
            left = newLink;
            
        }

        public void insertRight(long value)
        {
            Link newLink = new Link(value);

            if (isEmpty())
            {
                left= newLink;
            }
            else
            {
                right.next = newLink;
            }
            right = newLink;
        }

        public void removeLeft()
        {
            if (left.next == null)
            {
                right = null;
            }

            left = left.next;
        }

        public void removeRight()
        {
            Link curr = left;
            Link prev = null;

            while(curr.next!=null)
            {
                prev = curr;
                curr = curr.next;
            }

            right = prev;
            prev.next = null;
        }

        public void display()
        {
            Link current = left;
            while(current!=null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }

    class DequeueApp
    {
        static void Main(string[] args)
        {
            Dequeue one = new Dequeue();

            one.insertRight(1);
            one.insertRight(2);
            one.display();

            one.insertLeft(5);
            one.display();

            one.removeLeft();
            one.display();

            one.removeRight();
            one.display();

            one.insertLeft(55);
            one.insertLeft(5);
            one.insertLeft(12);
            one.display();

            one.insertRight(56);
            one.insertRight(6);
            one.display();
        }
    }
}
