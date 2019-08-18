using System;

namespace _6._5
{
    class Combinations
    {
        public static string[] array;
        static void Main(string[] args)
        {
            array = new string[] { "A", "B", "C", "D", "E" };

            Console.Write("Array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "");
            }

            Console.WriteLine();

            Console.Write("Enter the size of group: ");
            int size = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of elements in group: ");
            int numberOfElems = Convert.ToInt32(Console.ReadLine());

            showTeams(size, numberOfElems);
        }
        public static void showTeams(int n, int k)
        {
            for (int i = 0; i < n; i++) 
            {
                string A = array[i];

                for (int j = 1; j < n; j++) 
                {
                    Console.WriteLine(A + array[j]);
                }

;           }
        }
    }
}

