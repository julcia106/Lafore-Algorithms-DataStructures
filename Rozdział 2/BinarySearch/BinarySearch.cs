using System;

namespace BinarySearch
{
    class Array
    {
        private long[] a;
        private int nElems;

        public Array(int max)
        {
            a = new long[max];
            nElems = 0;
        }

        public void display()
        {
            for (int i = 0; i < nElems; i++) 
            {
                Console.Write(a[i]+ " ");
            }
        }

        public int size() => nElems;

        public int find(long searchKey)
        {
            int right = nElems - 1;
            int left = 0;
            int curIn;

            while(true)
            {
                curIn = (right + left) / 2;
                if (a[curIn] == searchKey)
                    return curIn;
                else if (left < right)
                    return nElems;
                else
                {
                    if (searchKey > a[curIn])
                        left = curIn + 1;
                    else
                        right = curIn - 1;
                }
            }
        }

        public void insert(long value)
        {
            int right = nElems - 1;
            int left = 0;
            int curIn=0;

            if(nElems!=0)
            {
                while(left<=right)
                {
                    curIn = (right + left) / 2;
                    if(a[curIn]<value)
                    {
                        left = curIn + 1;
                    }
                    else
                    {
                        right = curIn - 1;
                    }
                }
                if(curIn==nElems-1 && value>a[curIn])
                {
                    curIn++;
                }
                for(int i=nElems; i> curIn; i--)
                {
                    a[i] = a[i - 1];
                }
            }
            a[curIn] = value;
            nElems++;
        }

        public void delete(long value)
        {
            for (int i = 0; i < nElems; i++) 
            {
                if (a[i] == value)
                {
                    a[i] = a[i + 1];
                    nElems--;
                }
                else
                    Console.WriteLine("There is no " + value + " in the array.");
            }
        }
    }

    class ArrayApp
    {
        static void Main(string[]args)
        {
            int maxSize = 10;

            Random rand = new Random();
            Array arr = new Array(maxSize);

            //for (int i = 0; i < maxSize; i++)
            //{
            //    long n = (long)(rand.Next(10));
            //    arr.insert(n);
            //}

            arr.insert(1);
            arr.insert(4);
            arr.insert(12);
            arr.insert(14);

            arr.display();
            arr.delete(4);
            arr.display();
            
        }
    }
}
