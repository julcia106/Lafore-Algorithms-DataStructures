using System;

namespace conatiner
{
    class Link
    {
        public int data;
        public Link next;

        public Link(int value)
        {
            data = value;
            next = null;
        }

        public void displayNode()
        {
            Console.Write(data + " ");
        }
    }
    //--------------------------------------------------------------------------
    class ListIterator
    {
        private Link current;
        private Link previous;
        private LinkList ourList;           //lista, na której operuje iterator

        public ListIterator(LinkList list)  //konstruktor
        {
            ourList = list;
            reset();
        }

        public void reset()                 //powrót na początek listy
        {
            current = ourList.getFirst();
            previous = null;
        }

        public bool atEnd() => current.next == null;

        public void nextLink()
        {
            previous = current;
            current = current.next;
        }

        public Link getCurrent() => current;

        public void insertAfter(int data)
        {
            Link newLink = new Link(data);

            if (ourList.isEmpty())
            {
                ourList.setFirst(newLink);
                current = newLink;
            }
            else
            {
                newLink.next = current.next;
                current.next = newLink;
                nextLink();                     //przechodzimy do nowo wstawionego elementu
            }
        }

        public void insertBefore(int data)
        {
            Link newLink = new Link(data);

            if (previous == null)
            {
                newLink.next = ourList.getFirst();
                ourList.setFirst(newLink);
                reset();
            }
            else
            {
                newLink.next = previous.next;
                previous.next = newLink;
                current = newLink;
            }
        }

        public int deleteCurrent()
        {
            int value = current.data;

            if (previous == null)
            {
                ourList.setFirst(current.next);
                reset();
            }
            else
            {
                previous.next = current.next;
                if (atEnd())
                    reset();
                else
                    current = current.next;
            }
            return value;
        }
    }
    //-------------------------------------------------------------------------
    class LinkList
    {
        private Link first;

        public LinkList()
        {
            first = null;
        }

        public Link getFirst() => first;

        public void setFirst(Link f)                //ustawiamy referencję do pierwszego elementu
        {
            first = f;
        }

        public bool isEmpty() => first == null;

        public ListIterator getIterator()           //zwraca iterator
        {
            return new ListIterator(this);          //zainicjowany danymi (this)tej listy
        }

        public void displayList()
        {
            Link current = first;
            while (current != null)
            {
                current.displayNode();
                current = current.next;
            }
            Console.WriteLine();
        }
    }
    //--------------------------------------------------------------------------
    class CircularListApp
    {
        static void Main(string[] args)
        {
            LinkList one = new LinkList();              //new list

            ListIterator iter1 = one.getIterator();     //new iterator

            for (int i=1; i<= 20; i++)
            {
                iter1.insertAfter(i);
            }

            one.displayList();

            iter1.reset();
            iter1.deleteCurrent();
            while (!iter1.atEnd())
            {
                while (!iter1.atEnd())
                {
                    iter1.nextLink();
                    iter1.deleteCurrent();
                }
                iter1.reset();
            }

            one.displayList();
        }
    }
}
