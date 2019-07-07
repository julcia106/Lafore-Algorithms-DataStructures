//The removeMax() method in Programming Project 2.2 suggests a way to sort
//the contents of an array by key value.Implement a sorting scheme that does
//not require modifying the HighArray class, but only the code in main(). You’ll
//need a second array, which will end up inversely sorted. (This scheme is 
//rather crude variant of the selection sort in Chapter 3, “Simple Sorting.”)

using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    class ArrayApp
    {
        static void Main(string[] args)
        {
            int maxSize = 100; //array size
            Array arr;     //reference to array
            arr = new Array(maxSize); //create the array

            arr.insert(77);
            arr.insert(22);
            arr.insert(55);
            arr.insert(1);
            arr.insert(54);
            arr.insert(3);
            arr.insert(23);
            arr.insert(79);
            arr.insert(65);
            arr.insert(7);

            arr.display();


            Console.WriteLine("The value of the highest key in the array: " + arr.removeMax());
            Console.Write("Removing the highest value: ");
            arr.display();

            Array arr2 = new Array(maxSize);
            while (arr.getMax() != -1)
            {
                arr2.insert(arr.removeMax()); //sort
            }
            arr2.display();

            int searchKey = 35; //search for item
            if (arr.find(searchKey))
                Console.WriteLine("Found " + searchKey);
            else
                Console.WriteLine("Can't find " + searchKey);


            arr.delete(3);
            arr.delete(23);
            arr.delete(7);

            arr.display();
        }
    }
}
