using System;

namespace Dequeue
{
    class Queue
    {
        private int MaxSize;
        private int nElems;
        private int front;
        private int rear;
        private long[] dequeArray;

        public Queue(int n)
        {
            MaxSize = n;
            nElems = 0;
            front = 0;
            rear = -1;
            dequeArray = new long[MaxSize];
        }

        public void insertLeft(long value)
        {
            if (isFull())
                Console.WriteLine("Queue is full.");
            else
            {
                if (front == MaxSize)
                {
                    front = 0;
                }
                dequeArray[--front] = value;
                nElems++ ;
            }
        }

        public void insertRight(long value)
        {
            if (isFull())
                Console.WriteLine("Queue is full.");
            else
            {
                if (rear == MaxSize - 1)
                {
                    rear = -1;
                }
                dequeArray[++rear] = value;
                nElems++;

            }
        }

        public void removeLeft()
        {

        }

        public void removeRight()
        {
            if (isEmpty())
                Console.WriteLine("Cant remove. Queue is empty.");
            else
            {
                long temp = dequeArray[front++];
                if(front=MaxSize)
                {
                    front = 0;
                }
                nItems--;
                return temp;
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
    }

    class DequeueApp
    {
        static void Main(string[] args)
        {
            Queue one = new Queue(5);
        }
    }
}
