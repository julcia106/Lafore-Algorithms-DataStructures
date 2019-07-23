//4.4 The priority queue shown in Listing 4.6 features fast removal of the high-priority
//item but slow insertion of new items.Write a program with a revised
//PriorityQ class that has fast O(1) insertion time but slower removal of the highpriority
//item.Include a method that displays the contents of the priority
//queue, as suggested in Programming Project 4.1.

using System;

namespace Containter_Q
{
    class PriorityQ
    {
        // array in sorted order, from max at 0 to min at size-1
        private int maxSize;
        private long[] queArray;
        private int nItems;

        private void swap(long one, long two)
        {
            long temp = queArray[one];
            queArray[one] = queArray[two];
            queArray[two] = temp;
        }
        public PriorityQ(int s)    
        {
            maxSize = s;
            queArray = new long[maxSize];
            nItems = 0;
        }

        public void insert(long item)  
        {
            int j;

            if (nItems == 0)                         // if no items,
                queArray[nItems++] = item;         // insert at 0
            else                                // if items,
            {
                for (j = nItems - 1; j >= 0; j--)         // start at end,
                {
                    if (item > queArray[j])      // if new item larger,
                        queArray[j + 1] = queArray[j]; // shift upward
                    else                          // if smaller,
                        break;                     // done shifting
                }  // end for
                queArray[j + 1] = item;            // insert it
                nItems++;
            }  // end else (nItems > 0)
        }  

        public long remove()             // remove minimum item (front)
        { return queArray[--nItems]; } 

        //4.4
        public void insert2(long item)
        {
            if (isFull())
                Console.WriteLine("Queue is full.");
            else
                queArray[nItems++] = item;
        }

        //4.4
        public void remove2()
        {
            if (isEmpty())
                Console.WriteLine("Queue is empty.");
            else
            {
                long temp = queArray[nItems - 1]; //our minimum

                for (int i = nItems - 1; i >= 0; i--)
                {
                    if (temp > queArray[i])     //if there is value smaller than temp
                    {
                        temp = queArray[i];     //temp is this value now
                        queArray[i] = queArray[nItems - 1];   //the minimum value disappear because the nItems-1 value is copy on her place
                    }
                }
                nItems--; //remove the nItems-1 (one of the copy)
            }
        }

        public long peekMin()            // peek at minimum item
        { return queArray[nItems - 1]; }

        public Boolean isEmpty()         // true if queue is empty
        { return (nItems == 0); }

        public Boolean isFull()          // true if queue is full
        { return (nItems == maxSize); }

        public void display()
        {
            Console.Write("Rear--> ");
            for(int i=0; i<nItems; i++)
            {
                Console.Write(queArray[i] + " ");
            }
            Console.Write("--> Front");
            Console.WriteLine();
        }
    } 

    class PriorityQApp
    {
        static void Main(String[] args)
        {
            PriorityQ one = new PriorityQ(5);
            one.insert2(30);
            one.insert2(50);
            one.insert2(10);
            one.insert2(40);
            one.insert2(20);

            one.display();

            Console.WriteLine("Remove: ");
            while (!one.isEmpty())
            {
                long item = one.remove();
                Console.Write(item + " ");  // 10, 20, 30, 40, 50
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Second queue from 2.4 exercise: ");

            PriorityQ two = new PriorityQ(5);
            two.insert2(30);
            two.insert2(50);
            two.insert2(10);
            two.insert2(40);
            two.insert2(20);
            two.display();

            Console.WriteLine("Remove 10 and 20: ");
            two.remove2(); //10
            two.remove2(); //20
            two.display(); 
            Console.WriteLine("");
        }  
    }
}
