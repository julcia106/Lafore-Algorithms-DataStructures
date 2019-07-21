//4.2 Create a Deque class based on the discussion of deques(double-ended queues) in
//this chapter.It should include insertLeft(), insertRight(), removeLeft(),
//removeRight(), isEmpty(), and isFull() methods. It will need to support wraparound
//at the end of the array, as queues do.

//4.3 Write a program that implements a stack class that is based on the Deque class
//in Programming Project 4.2. This stack class should have the same methods
//and capabilities as the StackX class in the stack.java program (Listing 4.1).


using System;

namespace Dequeue
{
    class Queue
    {
        private int MaxSize;
        private int nElems;
        private int right;
        private int left;
        private long[] dequeArray;
        public Queue(int n)
        {
            MaxSize = n;
            nElems = 0;
            right = 0;
            left = 1;

            dequeArray = new long[MaxSize];
        }

        public void insertLeft(long value)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full.");
            }
            else
            {
                left--;
                if (left < 0)
                    left = MaxSize - 1;
                dequeArray[left] = value;
                nElems++;
            }
        }

        public void insertRight(long value)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full.");
            }
            else
            {
                right++;
                if (right >= MaxSize)
                    right = 0;
                dequeArray[right] = value;
                nElems++;
            }
        }
        public void removeLeft()
        {
            if (isEmpty())
            {
                Console.WriteLine("Cant remove. Queue is empty.");
            }
            else
            {
                left++;
                if (left >= MaxSize)
                    left = 0;
                nElems--;
            }
        }

        public void removeRight()
        {
            if (isEmpty())
            {
                Console.WriteLine("Cant remove. Queue is empty.");
            }
            else
            {
                right--;
                if (right < 0)
                    right = MaxSize - 1;
                nElems--;
            }
        }

        public Boolean isFull()
        {
            if (nElems == MaxSize)
                return true;
            else
                return false;
        }

        public Boolean isEmpty()
        {
            if (nElems == 0)
                return true;
            else
                return false;
        }

        public void display()
        {
            int index = left; 
            for(int i=0; i<nElems; i++)
            {
                if (index >= MaxSize)
                    index = 0;
                Console.Write(dequeArray[index] + " ");
                index++;
            }
            Console.WriteLine();
        }

        public long peek()
        {
            return dequeArray[right];
        }
    }
    //exercise 4.3
    class Stack
    {
        private Queue StackDeq;

        public Stack(int size)
        {
            StackDeq = new Queue(size);
        }

        public void push(long value)
        {
            StackDeq.insertRight(value);
        }

        public void pop()
        {
            StackDeq.removeRight();
        }

        public long peek()
        {
            return StackDeq.peek();
        }

        public Boolean isEmpty()
        {
            return StackDeq.isEmpty();
        }

        public Boolean isFull()
        {
            return StackDeq.isFull();
        }
    }

    class DequeueApp
    { 
        static void Main(string[] args)
        {
            Queue one = new Queue(5);
            if (one.isEmpty())
                Console.WriteLine("Queue is empty.");
            else
                Console.WriteLine("Queue is not empty.");

            Console.WriteLine("Insert Right: ");
            one.insertRight(7);
            one.insertRight(2);
            one.insertRight(3);
            one.display();

            Console.WriteLine("Insert left and right: ");
            one.insertLeft(8);
            one.insertRight(89);
            one.display();

            Console.WriteLine("Remove left: ");
            one.removeLeft();
            one.display();

            Console.WriteLine("Remove right: ");
            one.removeRight();
            one.display();

            //exercise 4.3
            Stack stack1 = new Stack(5);
            stack1.push(1);
            stack1.push(2);
            stack1.push(3);
            stack1.push(4);
            stack1.push(5);
            Console.WriteLine("The top value of Stack: " + stack1.peek());
            stack1.pop();
            Console.WriteLine("The top value of Stack: " + stack1.peek());

        }
    }
}
