using System;

namespace Container
{

    class Link
    {
        public int data;
       
        public Link right;
        public Link down;

        public Link(int d)
        {
            data = d;
            right = null;
            down = null;
        }
    }

    class Matrix
    {
        private int nColl;
        private int nRow;            //wiersze

        private Link first;
        private Link current;

        public Matrix(int coll, int r)
        {
            nColl = coll;
            nRow = r;

            first = new Link(0);
            current = first;

            Link temp;
            for (int i = 0; i < nRow; i++) 
            {
                temp = current;
                for (int j = 1; j < nColl; j++) 
                {
                    temp.right = new Link(0);
                    temp = temp.right;
                }
                if (i < nRow - 1) 
                {
                    current.down = new Link(0);
                    current = current.down;
                }
            }
        }

        public bool insert(int value, int row, int col)
        {
            if (row > nRow || col > nColl || row < 0 || col < 0)
            {
                Console.WriteLine("Must be in range (0,0) to (" + nRow + "," + nColl + ")");
                return false;
            }
            else
            {
                current = first;
                for (int i = 1; i < row; i++) 
                {
                    current = current.down;
                }
                for (int j = 1; j < col; j++) 
                {
                    current = current.right;
                }
                current.data = value;

                Console.WriteLine("Inserted " + value + " at (" + row + "," + col + ")");
                return true;
            }

        }
        public void display()
        {
            current = first;
            Link temp;
            while(current!= null)
            {
                temp = current;
                while (temp != null) 
                {
                    Console.Write(temp.data + "");
                    temp = temp.right;
                }
                Console.WriteLine();
                current = current.down;
            }
        }
    }
    class MatrixApp
    {
        static void Main(string[] args)
        {
            Matrix one = new Matrix(3, 3); //(row, coll)
            one.display();

            one.insert(1, 1, 1);
            one.insert(2, 1, 2); 
            one.insert(3, 1, 3); 
            one.insert(4, 2, 1); 
            one.insert(5, 2, 2); 
            one.insert(6, 2, 3); 
            one.insert(7, 3, 1); 
            one.insert(8, 3, 2); 
            one.insert(9, 3, 3);
            one.insert(4, 6, 7);

            one.display();

        }
    }
}
