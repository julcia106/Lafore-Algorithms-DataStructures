//3.1 In the bubbleSort.java program(Listing 3.1) and the BubbleSort Workshop
//applet, the in index always goes from left to right, finding the largest item and
//carrying it toward out on the right.Modify the bubbleSort() method so that it’s
//bidirectional.This means the in index will first carry the largest item from left
//to right as before, but when it reaches out, it will reverse and carry the smallest
//item from right to left. You’ll need two outer indexes, one on the right (the old
//out) and another on the left.

using System;
using System.Diagnostics;

namespace Bubble
{
    class ArrayBub
    {
        private long[] a;                 
        private int nElems;               

        public ArrayBub(int max)
        {
            a = new long[max];
            nElems = 0;
        }

        public void insert(long value)   
        {
            a[nElems] = value;            
            nElems++;                     
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

            while (outl != outr)
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
                    for (inn = outr; inn > outl; inn--)
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

            for (int j = 0; j < maxSize; j++)
            {
                long n = (long)(rand.Next(100));
                arr.insert(n);
            }

            Console.WriteLine("First display: ");
            arr.display();                // display items

            arr.bubbleSort();             // bubble sort them

            sw.Start();
            Console.WriteLine();
            Console.WriteLine("Display after diBubbleSort: ");
            arr.display();                // display them again
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("Elapsed={0} ", sw.Elapsed);
        }
    }
}


