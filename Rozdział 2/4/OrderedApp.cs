//2.4 Modify the orderedArray.java program(Listing 2.4) so that the insert() and
//delete() routines, as well as find(), use a binary search, as suggested in the
//text.
//2.5 Add a merge() method to the OrdArray class in the orderedArray.java
//program (Listing 2.4) so that you can merge two ordered source arrays into an
//ordered destination array.Write code in main() that inserts some random
//numbers into the two source arrays, invokes merge(), and displays the contents
//of the resulting destination array.The source arrays may hold different
//numbers of data items. In your algorithm you will need to compare the keys of
//the source arrays, picking the smallest one to copy to the destination.You’ll
//also need to handle the situation when one source array exhausts its contents
//before the other.

using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    class OrderedApp
    {
        static void Main(string[] args)
        {
            int maxSize = 100;             // array size
            OrdArray arr1;                  // reference to array
            OrdArray arr2;
            arr1 = new OrdArray(maxSize);   // create the array
            arr2 = new OrdArray(maxSize);

            arr1.insert(77);                // insert 10 items
            arr1.insert(8);
            arr1.insert(44);
            arr1.insert(55);
            arr2.insert(22);
            arr2.insert(88);
            arr2.insert(11);
            arr2.insert(00);
            arr2.insert(66);
            arr2.insert(33);

            arr1.display();
            arr2.display();

            OrdArray arr3 = OrdArray.merge(arr1, arr2);
            Console.WriteLine("After merge: ");
            arr3.display();

            int searchKey = 55;            // search for item
            if (arr1.find(searchKey) != arr1.size())
                Console.WriteLine("Found " + searchKey);
            else
                Console.WriteLine("Can't find " + searchKey);

            arr1.display();                 // display items

            arr1.delete(00);                // delete 3 items
            arr1.delete(55);
            arr1.delete(99);

            arr1.display();                 // display items again
        } 
    }  
}