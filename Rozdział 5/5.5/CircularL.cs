//5.5 The Josephus Problem is a famous mathematical puzzle that goes back to
//ancient times.There are many stories to go with the puzzle. One is that
//Josephus was one of a group of Jews who were about to be captured by the
//Romans. Rather than be enslaved, they chose to commit suicide.They arranged
//themselves in a circle and, starting at a certain person, started counting off
//around the circle. Every nth person had to leave the circle and commit suicide.
//Josephus decided he didn’t want to die, so he arranged the rules so he would
//be the last person left.If there were (say) 20 people, and he was the seventh
//person from the start of the circle, what number should he tell them to use for
//counting off? The problem is made much more complicated because the circle
//shrinks as the counting continues.
//Create an application that uses a circular linked list (like that in Programming
//Project 5.3) to model this problem.Inputs are the number of people in the
//circle, the number used for counting off, and the number of the person where
//248 CHAPTER 5 Linked Lists
//counting starts (usually 1). The output is the list of persons being eliminated.
//When a person drops out of the circle, counting starts again from the person
//who was on his left (assuming you go around clockwise). Here’s an example.
//There are seven people numbered 1 through 7, and you start at 1 and count off
//by threes. People will be eliminated in the order 4, 1, 6, 5, 7, 3. Number 2 will
//be left.

using System;

namespace containter
{
    class Link
    {
        public int data;
        public Link next;

        public Link(int d)
        {
            data = d;
            next = null;
        }
    }

    class CircularList
    {
        private Link curr;

        public CircularList()
        {
            curr = null;
        }

        public void insert(int value)
        {
            Link newLink = new Link(value);

            if(isEmpty())
            {
                newLink.next = newLink;
                curr = newLink;
            }
            else
            {
                newLink.next = curr.next;
                curr.next = newLink;
                curr = newLink;
            }
        }

        public void delete()
        {
            Link temp = curr;

            if(temp.next== curr)
            {
                curr = null;
            }
            else
            {
                do
                {
                    temp = temp.next;
                }
                while (temp.next != curr);
                {
                    temp.next = curr.next;
                    curr = temp;
                }
            }
        }

        public void display()
        {
            Link temp = curr;

            if(curr!= null)
            {
                do
                {
                    temp = temp.next;
                    Console.Write(temp.data + " ");
                }
                while (temp != curr);
                {
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        public void move()
        {
            if(!isEmpty())
            {
                curr = curr.next;
            }
        }

        public bool isEmpty()
        {
            return curr == null;
        }
    }

    class CircularListApp
    {
        static void Main(String[] args)
        {
            const int People = 20;
            const int Count = 5;

            CircularList one = new CircularList();

            for(int i=1; i<= People; i++)
            {
                one.insert(i);
            }

            while(!one.isEmpty())
            {
                one.display();
                for(int i=0; i< Count; i++)
                {
                    one.move();
                }
                one.delete();
            }
        }
    }
}