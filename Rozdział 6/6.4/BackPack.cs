using System;

namespace _6._4
{
    class BackPack
    {
        public static int[] array; // wagi elementów 
        static void Main(string[] args)
        {
            array = new int[] { 11, 8, 7, 6, 5 };

            Console.Write("Elements: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Our seeking value: 20");

            if (!Knapsack(20, 0))
                Console.WriteLine("Cant find any combination.");
        }
        public static bool Knapsack(int targetWeight, int index) //recursive method
        {
            bool isTrue = false;

            if (index == array.Length)
                return false;

            if (targetWeight == array[index]) // the number is correct
            {
                Console.WriteLine("Correct number: " + array[index]);
                return true;
            }
            else if (targetWeight > array[index])   // the number is too small 
            {
                isTrue= Knapsack((targetWeight - array[index]), index + 1);
                if(isTrue)
                {
                    Console.WriteLine("Correct number: " + array[index] + "");
                }

                for (int i = index + 1; i < array.Length; i++) 
                {
                    if (!isTrue)
                        isTrue = Knapsack(targetWeight, i);
                }
            }
            else // the number is too big
            {
                isTrue = Knapsack(targetWeight, index + 1);
            }
            return isTrue;
        }

    }
}
