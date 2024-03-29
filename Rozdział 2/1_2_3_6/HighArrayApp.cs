﻿//2.1 To the HighArray class in the highArray.java program (Listing 2.3), add a
//method called getMax() that returns the value of the highest key in the array,
//or –1 if the array is empty.Add some code in main() to exercise this method.
//You can assume all the keys are positive numbers.

//2.2 Modify the method in Programming Project 2.1 so that the item with the
//highest key is not only returned by the method, but also removed from the
//array.Call the method removeMax().

//2.3 The removeMax() method in Programming Project 2.2 suggests a way to sort
//the contents of an array by key value.Implement a sorting scheme that does
//not require modifying the HighArray class, but only the code in main(). You’ll
//need a second array, which will end up inversely sorted. (This scheme is 
//rather crude variant of the selection sort in Chapter 3, “Simple Sorting.”)

//2.6 Write a noDups() method for the HighArray class of the highArray.java
//program (Listing 2.3). This method should remove all duplicates from the
//array.That is, if three items with the key 17 appear in the array, noDups()
//should remove two of them.Don’t worry about maintaining the order of the
//items.One approach is to first compare every item with all the other items and
//overwrite any duplicates with a null (or a distinctive value that isn’t used for
//real keys). Then remove all the nulls.Of course, the array size will be reduced.

using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    class HighArrayApp
    {
        static void Main(string[] args)
        {
            int maxSize = 100; //array size
            Array arr;     //reference to array
            arr = new Array(maxSize); //create the array

            arr.insert(77);
            arr.insert(22);
            arr.insert(55);
            arr.insert(7);
            arr.insert(54);
            arr.insert(3);
            arr.insert(23);
            arr.insert(79);
            arr.insert(65);
            arr.insert(7);

            arr.display();

            arr.noDups();

            Console.WriteLine("After noDups: ");
            arr.display();

            int searchKey = 35; //search for item
            if (arr.find(searchKey))
                Console.WriteLine("Found " + searchKey);
            else
                Console.WriteLine("Can't find " + searchKey);

            Console.WriteLine("The value of the highest key in the array: " + arr.removeMax());
            Console.Write("Removing the highest value: ");
            arr.display();

            // 2.3
            Array arr2 = new Array(maxSize);
            while (arr.getMax() != -1)
            {
                arr2.insert(arr.removeMax()); //sort
            }
            arr2.display();
        }
    }
}