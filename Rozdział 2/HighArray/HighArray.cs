using System;

namespace _1
{
    class Array
    {
        private long[] a; //ref to array a
        private int nElems; // number of data items

        public Array(int max) //constructor
        {
            a = new long[max]; //create the array
            nElems = 0; //no items yet
        }

        public Boolean find(long searchKey)
        {
            //fin special value
            int j;
            for (j = 0; j < nElems; j++) // for each element,
                if (a[j] == searchKey) //found item?
                    break; //exit loop before end
            if (j == nElems) //gone to end?
                return false; // yes, can't find it
            else
                return true; //no, found it
        }

        public void insert(long value) // put element into array
        {
            a[nElems] = value; //insert it 
            nElems++; //increment size
        }

        public Boolean delete(long value)
        {
            int j;
            for (j = 0; j < nElems; j++) //look for it
                if (value == a[j])
                    break;
            if (j == nElems) //cant find it
                return false;
            else             //found it 
            {
                for (int k = j; k < nElems; k++)
                    a[k] = a[k + 1]; //move higher ones down
                nElems--; //decrement size
                return true;
            }
        }

        public void display() // display array contents
        {
            for (int j = 0; j < nElems; j++) //for each element,
                Console.Write(a[j] + " "); //display it
            Console.WriteLine(" ");
        }

        public long getMax()
        {
            if (nElems == 0)
                return -1;
            else
            {
                long max = a[0];
                for (int i = 0; i < nElems; i++)
                {
                    if (max < a[i])
                        max = a[i];
                }

                return max;
            }
        }

        public long removeMax()
        {

            if (nElems == 0)
                return -1;
            else
            {
                long max = a[0];
                for (int j = 0; j < nElems; j++)
                {
                    if (max < a[j])
                        max = a[j];
                }
                delete(max);
                return max;
            }
        }

        public void noDups()
        {
            long value;
            int size = nElems - 1;
            int i, j, k;

            for (i = 0; i <= size; i++)
            {
                value = a[i];

                for (j = i + 1; j <= size; j++)
                {
                    if (a[j] == value)
                    {
                        for (k = j; k < size; k++)
                        {
                            a[k] = a[k + 1];
                        }
                        nElems--;
                        j--;
                        size--;

                    }
                }
            }
        }


    }
}
