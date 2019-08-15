//6.1 Suppose you buy a budget-priced pocket PC and discover that the chip inside
//can’t do multiplication, only addition.You program your way out of this
//quandary by writing a recursive method, mult(), that performs multiplication
//of x and y by adding x to itself y times. Its arguments are x and y and its return
//value is the product of x and y. Write such a method and a main() program to
//call it.
//6.3 Implement the recursive approach to raising a number to a power, as described
//in the “Raising a Number to a Power” section near the end of this chapter.
//Write the recursive power() function and a main() routine to test it.

using System;

namespace Recursion
{
    class Computer
    {
        public int Mult(int y, int x)
        {
            if (x == 0) 
            {
                return 0;
            }
            else
            {
                return (y + Mult(y, x - 1));
            }
        }

        public int NumToPower(int x, int y)
        {
            if (y == 1)         // end 
            {
                return x;
            }
            else if (y % 2 == 1)   // y is odd number
            {
                return x * NumToPower(x, y - 1);
            }
            else
            {
                return NumToPower(x * x, y / 2);
            }
            
        }

        static void Main(string[] args)
        {
            Computer one = new Computer();
            Console.WriteLine(one.Mult(2,3));
            Console.WriteLine(one.NumToPower(2, 5));
        }
    }
}
