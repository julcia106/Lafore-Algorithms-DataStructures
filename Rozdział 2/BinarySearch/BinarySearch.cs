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
            Console.WriteLine("");
        }

        public int size() => nElems;

        public int iterative_find(long searchKey)
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

        public int recursive_find(long searchKey,int left,int right)
        {
            if (left > right)
                return -1;

            int curIn = (left + right) / 2;
            if (a[curIn] == searchKey)
                return curIn;

            else if (searchKey < a[curIn])
            {
                return recursive_find(searchKey, left, curIn - 1);
            }
            else
                return recursive_find(searchKey, curIn + 1, right);
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
            for(int i=0; i<nElems; i++)
            {
                if (a[i] == value)
                {
                    for (int j = i; j < nElems; j++)
                        a[j] = a[j + 1];
                    nElems--;
                }
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
            arr.insert(2);
            arr.insert(8);
            arr.insert(12);
            arr.insert(22);
            arr.insert(55);
            arr.insert(56);
            arr.insert(59);
            arr.insert(60);
            arr.insert(66);

            arr.display();

            Console.WriteLine("Index of your searchKey: " + arr.recursive_find(2, 0, 9));
            Console.WriteLine("Index of your searchKey: " + arr.iterative_find(59));
        }
    }
}
