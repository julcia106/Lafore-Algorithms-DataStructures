using System;

namespace list
{
    class Link
    {
        public int data;
        public Link next;

        public Link(int d)
        {
            data = d;
            next = null;
        }
    }
    class CircularList
    {
        private Link current;
        private int nElems;

        public CircularList()
        {
            current = null;
            nElems = 0;
        }

        public void insert(int value)
        {
            Link newLink = new Link(value);

            if (isEmpty())
            {
                current = newLink;
                current.next = current;
            }
            else
            {
                newLink.next = current.next;
                current.next = newLink;
                current = newLink;
            }
            nElems++;
        }

        public void remove()
        {
            if (isEmpty())
                Console.WriteLine("Circular list is empty.");
            else if(nElems==1)
            {
                current = null;
                nElems = 0;
            }
            else
            {
                current.next = current.next.next;
                nElems--;
            }
        }

        public Link Find(int value)
        {
            if (current.data == value)
            {
                return current;
            }
            else
            {
                int temp = current.data;
                step();

                while (current.data != value)
                {
                    if (current.data == temp)
                        return null;
                    else
                        step();
                }
                return current;
            }
        }

        public void display()
        {
            int lastElem = current.data;

            step();
            while (current.data != lastElem)
            {
                Console.Write(current.data + " ");
                step();
            }
            Console.Write(lastElem + " ");

            Console.WriteLine();
        }

        public void step()
        {
            current = current.next;
        }

        public bool isEmpty()
        {
            if (nElems == 0)
                return true;
            else
                return false;
        }

        public Link currentVal()
        {
            return current;
        }
    }

    class Stack
    {
        private CircularList theStack;
        private int curr;
        private int size;

        public Stack()
        {
            theStack = new CircularList();
            size = 0;
            curr = 0;
        }
        public void push(int value)
        {
            theStack.insert(value);
            curr++;
        }

        public void pop()
        {
            theStack.remove();
            curr--;
        }

        public bool isEmpty()
        {
            return theStack.isEmpty();
        }

        public void display()
        {
            theStack.display();
        }

    }
    class CircularListApp
    {
        static void Main(string[] args)
        {
            CircularList one = new CircularList();

            one.insert(1);
            one.insert(2);
            one.insert(3);
            one.insert(4);
            one.insert(5);
            one.display();

            one.remove();
            one.display();

            one.Find(4);

            Console.WriteLine("Stack: ");

            Stack stack1 = new Stack();

            stack1.push(1);
            stack1.push(2);
            stack1.push(3);
            stack1.push(4);
            stack1.push(5);
            stack1.display();

            stack1.pop();
            stack1.pop();
            stack1.display();
        }
    }
}
