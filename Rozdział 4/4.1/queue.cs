//4.1 Write a method for the Queue class in the queue.java program (Listing 4.4) that
//displays the contents of the queue.Note that this does not mean simply
//displaying the contents of the underlying array.You should show the queue
//contents from the first item inserted to the last, without indicating to the
//viewer whether the sequence is broken by wrapping around the end of the
//array.Be careful that one item and no items display properly, no matter where
//front and rear are.

using System;

namespace Queue
{
    class Queue
    {
        private int maxSize;
        private long[] queArray;
        private int front;
        private int rear;
        private int nItems;
        public Queue(int s)     
        {
            maxSize = s;
            queArray = new long[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        public void insert(long j)   // put item at rear of queue
        {
            if (rear == maxSize - 1)         // deal with wraparound
                rear = -1;
            queArray[++rear] = j;         // increment rear and insert
            nItems++;                     // one more item
        }
        public long remove()         // take item from front of queue
        {
            long temp = queArray[front++]; // get value and incr front
            if (front == maxSize)           // deal with wraparound
                front = 0;
            nItems--;                      // one less item
            return temp;
        } 
        public long peekFront()      // peek at front of queue
        {
            return queArray[front];
        }
        public Boolean isEmpty()    // true if queue is empty
        {
            return (nItems == 0);
        }
        public Boolean isFull()     // true if queue is full
        {
            return (nItems == maxSize);
        }
        public int size()           // number of items in queue
        {
            return nItems;
        }

        public void display()
        {
            if(nItems==0)
            {
                Console.WriteLine("Queue is empty.");
            }
            else
            {
                Console.Write("Queue: ");
                for(int i=0; i<nItems; i++)
                {
                    Console.Write(queArray[i]+ " ");
                } 
                Console.WriteLine();
            }
        }
    } 
    class QueueApp
    {
        static void Main(String[] args)
        {
            Queue theQueue = new Queue(5);  // queue holds 5 items

            theQueue.insert(10);            // insert 4 items
            theQueue.insert(20);
            theQueue.insert(30);
            theQueue.insert(40);

            theQueue.remove();              // remove 3 items
            theQueue.remove();              
            theQueue.remove();

            theQueue.insert(50);            // insert 4 more items
            theQueue.insert(60);            //    (wraps around)
            theQueue.insert(70);
            theQueue.insert(80);

            theQueue.display();

        }  
    }
}
