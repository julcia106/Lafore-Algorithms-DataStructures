using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    class HighArrayApp
    {
        static void Main(string []args)
        {
            int maxSize = 100; //array size
            HighArray arr;     //reference to array
            arr = new HighArray(maxSize); //create the array

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


            Console.WriteLine("The value of the highest key in the array: " + arr.getMax());

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
