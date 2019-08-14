using System;

namespace Task
{
    public class BinaryTree
    {
        public static String[] array;
        static void Main(String[] args)
        {
            int lineSize = 32;
            int numLines = 5;
                //(int)(Math.Log(lineSize) / Math.Log(2)) + 1;
            array = new String[numLines];

            for (int i = 0; i < array.Length; i++)
                array[i] = "";

            MakeBranches(0, lineSize - 1, 0);

            Display(array);
        }
        public static void MakeBranches(int left, int right, int width) //recursive method
        {
            if (left - right == 0)
                return;
          
            int center = (left + right) / 2;

            for (int i = left; i < right; i++)  
            {
                if (i == center) 
                {
                    array[width] += 'X';
                }
                else
                {
                    array[width] += '-';
                }
            }
            MakeBranches(left, center, width + 1);
            MakeBranches(center + 1, right, width + 1);
        }
        public static void Display(string[] arr)
        {
            for(int i=0; i< arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
