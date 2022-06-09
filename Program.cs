using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            MySortedList glist1 = new MySortedList();
            MySortedList glist2 = new MySortedList();
            Console.WriteLine();
            Console.WriteLine("_____________CREATING FIRST LIST____________");
            for (int i = 0; i < 6; i++)
            {
                var add = rnd.Next(-143, 414);
                glist1.AddWithSort(add);

            }
            Element current = glist1.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);
            
            Console.WriteLine("_____________CREATING SECOND LIST____________");
            for (int i = 0; i < 6; i++)
            {
                var add = rnd.Next(-43, 44);
                glist2.AddWithSort(add);
            }

            current = glist2.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);

            Console.WriteLine("_____________UNITING OF BOTH LISTS____________");
            var result = MySortedList.ToUnite(glist1, glist2);
            current = result.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);
            
            MySortedList lst1 = new MySortedList();
            MySortedList lst2 = new MySortedList();
            for (int i = 20; i >= 10; i -= 2)
            {
                lst1.AddLast(i);
                lst2.AddFirst(i);
            }

            System.Console.WriteLine("___________Adding Last in third list_____________");
            current = lst1.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);

            System.Console.WriteLine("___________Adding First in fourth list_____________");
            current = lst2.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);

            System.Console.WriteLine("___________Deleting first element in third list_____________");
            lst1.DeleteByIndex(0);
            current = lst1.First;
            do
            {
                if (current != null)
                {
                    Console.WriteLine(current.Info);
                    current = current.Next;
                }
            }
            while (current != null);

            glist1.Clear("glist1");
            glist2.Clear("glist2");
            lst1.Clear("lst1");
            lst2.Clear("lst2");
            System.Console.WriteLine("___________Deleted all lists_____________");
        }
    }
}
