using System;
using System.Diagnostics;

namespace _3a
{
    class ArrayBub
    {
        private long[] a;                 // ref to array a
        private int nElems;               // number of data items

        public ArrayBub(int max)        
        {
            a = new long[max];                 
            nElems = 0;                        
        }

        public void insert(long value)    // put element into array
        {
            a[nElems] = value;             // insert it
            nElems++;                      // increment size
        }

        public void display()       
        {
            for (int j = 0; j < nElems; j++)       
                Console.Write(a[j] + " ");  
            Console.WriteLine("");
        }

        public void bubbleSort()
        {
            int outl = 0;
            int outr = nElems - 1;
            int inn;
            int pt = 1;

            while(outl!=outr)
            {
                if (pt == 1)
                {
                    for (inn = outl; inn < outr; inn++)
                    {
                        if (a[inn] > a[inn + 1])
                            swap(inn, inn + 1);
                    }
                    outr--;
                    pt = -1;
                }
                else
                {
                    for(inn=outr; inn>outl; inn--)
                    {
                        if (a[inn] < a[inn - 1])
                            swap(inn, inn - 1);
                    }
                    outl++;
                    pt = -1;
                }
            }
        }

        private void swap(int one, int two)
        {
            long temp = a[one];
            a[one] = a[two];
            a[two] = temp;
        }
    }

    class BubbleSortApp
    {
        static void Main(String[] args)
        {
            int maxSize = 10;            // array size
            ArrayBub arr;                 // reference to array

            Random rand = new Random();
            arr = new ArrayBub(maxSize);  // create the array
            Stopwatch sw = new Stopwatch();

            for(int j=0; j<maxSize; j++)
            {
                long n = (long)(rand.Next(100));
                arr.insert(n);
            }

            Console.WriteLine("Pierwsze display: ");
            arr.display();                // display items

            arr.bubbleSort();             // bubble sort them

            sw.Start();
            Console.WriteLine();
            Console.WriteLine("Display po bubble sorcie: ");
            arr.display();                // display them again
            sw.Stop();
            Console.WriteLine("Elapsed={0} ", sw.Elapsed);
        }  
    }
}


