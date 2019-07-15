//3.2 Add a method called median() to the ArrayIns class in the insertSort.java
//program. This method should return the median value in the array. 
//(Recall that in a group of numbers half are larger than the median and half are smaller.) Do it the easy way.

//3.3 To the insertSort.java program, add a method called noDups() that
//removes duplicates from a previously sorted array without disrupting the order.
// One can imagine schemes in which all the items from the place where a duplicate 
//was discovered to the end of the array would be shifted down one space every time 
//a duplicate was discovered, but this would lead to slow O(N2) time, at least when 
//there were a lot of duplicates.In your algorithm, make sure no item is moved more than
//once, no matter how many duplicates there are.This will give you an algorithm
//with O(N) time.

//3.5 Modify the insertionSort() method in insertSort.java so it counts
//the number of copies and the number of comparisons it makes during a sort
//and displays the totals.To count comparisons, you’ll need to break up the
//double condition in the inner while loop.

//3.6 The insertion sort uses a loop-within-a-loop algorithm that compares every 
//item in the array with every other item. If you want to remove duplicates, 
//this is one way to start. Modify the insertionSort() method in the
//insertSort.java program so that it removes duplicates as it sorts. Here’s one
//approach: When a duplicate is found, write over one of the duplicated items
//with a key value less than any normally used (such as –1, if all the normal keys
//are positive). Then the normal insertion sort algorithm, treating this new key
//like any other item, will put it at index 0. From now on the algorithm can
//ignore this item.The next duplicate will go at index 1, and so on.When the
//sort is finished, all the removed dups (now represented by –1 values) will be
//found at the beginning of the array. The array can then be resized and shifted
//down so it starts at 0.

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
            int cr = 0;             //comparison
            int cp = 0;             //copy

            for (outt= 1; outt< nElems; outt++)   
            {
                long temp = a[outt]; cp++;
                inn = outt;

                while (inn > 0)
                {
                    if (a[inn - 1] >= temp)
                    {
                        a[inn] = a[inn - 1]; cp++;
                        --inn;
                        cr++;
                    }
                    else
                        break;
                }
                a[inn] = temp; cp++;
            }  
                Console.WriteLine("number of copies: " + cp);
                Console.WriteLine("Number of comparisons: " + cr);
        }  

        public void noDupsInserionSort()
        {
            int inn, outt;
            int dups = 0;

            for(outt=1; outt< nElems; outt++)
            {
                long temp = a[outt];
                inn = outt;

                while (inn>0 && a[inn-1]>=temp)
                {
                    if(a[inn-1]==temp)
                    {
                        temp = -1;
                        dups++;
                    }
                    
                    a[inn] = a[inn - 1];
                    inn--;
                }

                a[inn] = temp;
            }
            if(dups!=0)
            {
                for (int i = dups; i < nElems; i++)
                    a[i - dups] = a[i];
            }
            nElems -= dups;
            Console.WriteLine("Dups: " + dups);
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

        public void noDups()
        {
            int temp = 0;
           for(int i=0, j=1; j<nElems; j++)
            {
                if (a[i] == a[j])
                {
                    temp++;
                }
                else
                {
                    i++;
                    a[i] = a[j];
                }
               
            }
            nElems -= temp;
        }
    }

    class InsertSortApp
    {
        static void Main(String[] args)
        {
            int maxSize = 100;          
            ArrayIns arr;                 
            arr = new ArrayIns(maxSize);  

            arr.insert(1);               
            arr.insert(2);               
            arr.insert(6);               
            arr.insert(7);               
            arr.insert(7);               
            arr.insert(65);               
            arr.insert(5);               
            arr.insert(65);               

            arr.display();                

            //arr.insertionSort();          

            //arr.display();

            Console.WriteLine();
            Console.WriteLine("Median value: " + arr.median());

            arr.noDupsInserionSort();
            arr.display();
        } 
    }  
}
