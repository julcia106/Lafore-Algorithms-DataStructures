//3.2 Add a method called median() to the ArrayIns class in the insertSort.java
//program (Listing 3.3). This method should return the median value in the
//array. (Recall that in a group of numbers half are larger than the median and
//half are smaller.) Do it the easy way.

using System;

namespace InsSort
{
    class ArrayIns
    {
        private long[] a;                 
        private int nElems;               
                                        
        public ArrayIns(int max)         
        {
            a = new long[max];                
            nElems = 0;                        
        }
        
        public void insert(long value)    // put element into array
        {
            a[nElems] = value;             
            nElems++;                      
        }
        
        public void display()             // displays array contents
        {
            for (int j = 0; j < nElems; j++)      
                Console.Write(a[j] + " ");  
            Console.WriteLine("");
        }
        
        public void insertionSort()
        {
            int inn, outt;

            for (outt= 1; outt< nElems; outt++)     // out is dividing line
         {
                long temp = a[outt];            // remove marked item
                inn = outt;                      // start shifts at out
                while (inn> 0 && a[inn -1] >= temp) // until one is smaller,
            {
                    a[inn] = a[inn -1];            // shift item to right
                    --inn;                       // go left one position
                }
                a[inn] = temp;                  // insert marked item
            }  
        }  

        public long median()
        {
            long sum = 0;
            int i = 0;

            while(i!=nElems)
            {
                sum += a[i];
                i++;
            }

            return (sum / nElems);
        }
    }

    class InsertSortApp
    {
        static void Main(String[] args)
        {
            int maxSize = 100;          
            ArrayIns arr;                 
            arr = new ArrayIns(maxSize);  

            arr.insert(77);               
            arr.insert(99);
            arr.insert(44);
            arr.insert(55);
            arr.insert(22);
            arr.insert(88);
            arr.insert(11);
            arr.insert(00);
            arr.insert(66);
            arr.insert(33);

            arr.display();                

            arr.insertionSort();          

            arr.display();

            Console.WriteLine("Median value: "+ arr.median());
        } 
    }  
}
