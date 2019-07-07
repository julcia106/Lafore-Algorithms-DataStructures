//Modify the method in Programming Project 2.3 so that the item with the
//highest key is not only returned by the method, but also removed from the array.
//Call the method removeMax().

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
