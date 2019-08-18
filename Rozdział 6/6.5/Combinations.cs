using System;

namespace _6._5
{
    class Combinations
    { 
        static void Main(string[] args)
        {
            String str = "";
            int teamSize = 5;
            int groupSize = 3;
            showTeams(teamSize, groupSize, str, 'A', groupSize - 1);
        }
        public static void showTeams(int n, int k, String str, char ch, int size)
        {
            if (n== 0 || k== 0 || k > n) 
            {
                return;
            }

            str += Convert.ToString(ch);
            ch++;

            showTeams(n - 1, k - 1, str, ch, size);
            str = str.Substring(0, str.Length - 1);

            if (str.Length == size)
                Console.WriteLine(str + (char)(ch - 1));

            showTeams(n - 1, k, str, ch, size);
        }
    }
}

