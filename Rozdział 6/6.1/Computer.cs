//6.1 Suppose you buy a budget-priced pocket PC and discover that the chip inside
//can’t do multiplication, only addition.You program your way out of this
//quandary by writing a recursive method, mult(), that performs multiplication
//of x and y by adding x to itself y times. Its arguments are x and y and its return
//value is the product of x and y. Write such a method and a main() program to
//call it.

using System;

namespace Recursion
{
    class Computer
    {
        public int mult(int y, int x)
        {
            if (x == 0) 
            {
                return 0;
            }
            else
            {
                return (y + mult(y, x - 1));
            }
        }
        static void Main(string[] args)
        {
            Computer one = new Computer();
            Console.WriteLine(one.mult(2,3));
        }
    }
}
