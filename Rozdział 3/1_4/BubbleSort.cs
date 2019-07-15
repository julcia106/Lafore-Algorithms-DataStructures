//3.1 In the bubbleSort.java program and the BubbleSort Workshop
//applet, the in index always goes from left to right, finding the largest item and
//carrying it toward out on the right.Modify the bubbleSort() method so that it’s
//bidirectional.This means the in index will first carry the largest item from left
//to right as before, but when it reaches out, it will reverse and carry the smallest
//item from right to left. You’ll need two outer indexes, one on the right (the old
//out) and another on the left.

//3.4 Another simple sort is the odd-even sort.The idea is to repeatedly make two
//passes through the array. On the first pass you look at all the pairs of items,
//a[j] and a[j + 1], where j is odd (j = 1, 3, 5, …). If their key values are out of
//  order, you swap them.On the second pass you do the same for all the even
//  values (j = 2, 4, 6, …). You do these two passes repeatedly until the array is
//sorted.Replace the bubbleSort() method in bubbleSort.java with
//an oddEvenSort() method.Make sure it works for varying amounts of data.

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

        public void oddEvenSort()
        {
            Boolean next = true;

            while (next)
            {
                next = false;
                for (int i = 1; i < nElems - 1; i += 2)
                {
                    if (a[i] > a[i + 1])
                    {
                        swap(i, i + 1);
                        next = true;
                    }
                }

                for (int j = 0; j < nElems - 1; j += 2)
                {
                    if (a[j] > a[j + 1])
                    {
                        swap(j, j + 1);
                        next = true;
                    }
                }
            }
        }

        private void swap(long one, long two)
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
            int maxSize = 10; 
            
            ArrayBub arr2 = new ArrayBub(maxSize);
            ArrayBub arr;

            Random rand = new Random();
            arr = new ArrayBub(maxSize);  // create the array
            Stopwatch sw = new Stopwatch();

            for (int j = 0; j < maxSize; j++)
            {
                long n = (long)(rand.Next(100));
                arr.insert(n);
            }



            Console.WriteLine("First arr display: ");
            arr.display();                // display items

            arr.bubbleSort();             // bubble sort them

            sw.Start();
            Console.WriteLine();
            Console.WriteLine("Display arr after diBubbleSort: ");
            arr.display();                // display them again
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("Elapsed={0} ", sw.Elapsed);
            Console.WriteLine();

            arr2.insert(2);
            arr2.insert(1);
            arr2.insert(47);
            arr2.insert(4);
            arr2.insert(24);
            arr2.insert(14);
            arr2.insert(39);

            Console.WriteLine("Display arr2 after oddEvenSort: ");
            arr2.oddEvenSort();
            arr2.display();
        }
    }
}


