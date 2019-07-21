//Answer to this exercise is in project 4.2
//I just wrote a regular Stack here for practise. 
using System;

namespace Containers
{
    class Stack
    {
        private int top;
        private int MaxSize;
        private long[] stackArray;

        public Stack(int n)
        {
            top = -1;
            MaxSize = n;
            stackArray = new long [MaxSize];
        }

        public void push(long value)
        {
            if (isFull())
                Console.WriteLine("Stack is full.");
            else
            {
                top++;
                if (top >= MaxSize)
                    top = 0;
                stackArray[top] = value;
            }
        }

        public void pop()
        {
            if (isEmpty())
                Console.WriteLine("Stack is empty.");
            else
            {
                top--;
                if (top < 0)
                    top = MaxSize - 1;
            }
        }

        public Boolean isFull()
        {
            if (top == MaxSize-1)
                return true;
            else
                return false;
        }

        public Boolean isEmpty()
        {
            if (top == -1)
                return true;
            else
                return false;
        }

        public long peek()
        {
            return stackArray[top];
        }

        public void display()
        {
            int index = 0;
            for(int i=0; i<MaxSize; i++)
            {
                if (index > top)
                    index = 0;
                Console.WriteLine(stackArray[index] + " ");
                index++;
            }
        }
    }
    class StackApp
    {
        static void Main(string[] args)
        {
            Stack one = new Stack(5);
            one.push(1);
            one.push(2);
            one.push(3);
            one.push(4);
            one.push(4);
            one.pop();
            one.push(32);
            Console.WriteLine("Value on the top of the stack: " + one.peek());
            one.display();
        }
    }
}
