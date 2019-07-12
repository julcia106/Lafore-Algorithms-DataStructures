using System;

namespace _3
{
    class OrdArray
    {
        private long[] a;                 // ref to array a
        private int nElems;               // number of data items
        public OrdArray(int max)          // constructor
        {
            a = new long[max];             // create array
            nElems = 0;
        }

        public int size() => nElems;

        public int find(long searchKey)
        {
            int lowerBound = 0;
            int upperBound = nElems - 1;
            int curIn;

            while (true)
            {
                curIn = (lowerBound + upperBound) / 2;
                if (a[curIn] == searchKey)
                    return curIn;              // found it
                else if (lowerBound > upperBound)
                    return nElems;             // can't find it
                else                          // divide range
                {
                    if (a[curIn] < searchKey)
                        lowerBound = curIn + 1; // it's in upper half
                    else
                        upperBound = curIn - 1; // it's in lower half
                }
            }
        }
        public void insert(long value)    // put element into array
        {

            int i = 0;
            int lowerBound = 0;
            int upperBound = nElems - 1;

            if (nElems != 0)
            {
                while (lowerBound <= upperBound)
                {
                    i = (lowerBound + upperBound) / 2;
                    if (a[i] < value)
                    {
                        lowerBound = i + 1;
                    }
                    else
                    {
                        upperBound = i - 1;
                    }
                }
                if (i == nElems - 1 && value > a[i])
                {
                    i++;
                }
                for (int k = nElems; k > i; k--)
                {
                    a[k] = a[k - 1];
                }
            }
            a[i] = value;
            nElems++;
        }

        public Boolean delete(long value)
        {
            int j = find(value);
            if (j == nElems)                  // can't find it
                return false;
            else                           // found it
            {
                for (int k = j; k < nElems; k++) // move bigger ones down
                    a[k] = a[k + 1];
                nElems--;                   // decrement size
                return true;
            }
        }

        public void display()             // displays array contents
        {
            for (int j = 0; j < nElems; j++)       // for each element,
                Console.Write(a[j] + " ");  // display it
            Console.WriteLine("");
        }

        public void setVal(int index, long value)
        {
            a[index] = value;
        }

        public long getVal(int index) => a[index];

        public static OrdArray merge(OrdArray arr1, OrdArray arr2)
        {
            int size = arr1.size() + arr2.size();
            OrdArray arr = new OrdArray(size);

            int i = 0;
            int j = 0;
            int k = 0;
            while (j < arr1.size() && k < arr2.size())
            {
                if (arr1.getVal(j) < arr2.getVal(k))
                {
                    arr.setVal(i, arr1.getVal(j));
                    j++;
                }
                else if (arr1.getVal(j) > arr2.getVal(k))
                {
                    arr.setVal(i, arr2.getVal(k));
                    k++;
                }
                else
                {
                    arr.setVal(i, arr1.getVal(j));
                    arr.setVal(i, arr2.getVal(k));
                    j++;
                    k++;
                }
                arr.nElems++;
                i++;
            }
            //ostatni warunek jeżeli któraś tablica jest dłuższa 

            while (j < arr1.size())
            {
                arr.setVal(i, arr1.getVal(j));
                j++;
                i++;
                arr.nElems++;
            }

            while (k < arr2.size())
            {
                arr.setVal(i, arr2.getVal(k));
                k++;
                i++;
                arr.nElems++;
            }

            return arr;
        }
    }
}