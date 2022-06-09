using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2SortedList
{
    public class MySortedList
    {

        public Element First;

        public MySortedList(){
            deletion += DisplayMessage;
            deletionList += DisplayMessageClearList;
        }

        public delegate void EventHandler(string message, Element data);
        public delegate void ClearListHandler(string message, string data);
        public event EventHandler deletion = delegate { };
        public event ClearListHandler deletionList = delegate { };

        public void AddFirst(int x)
        {
            var newElement = new Element() { Info = x, Next = First };
            First = newElement;
        }

        public void AddLast(int x)
        {
            var newElem = new Element() { Info = x };

            if (First == null)
            {
                First = newElem;
                return;
            }
            var elem = First;
            while (elem.Next != null)
                elem = elem.Next;

            elem.Next = newElem;
        }

        public void AddWithSort(int x) //add new elem according frm min-to-max sort
        {
            if (First == null)
            {
                First = new Element() { Info = x };
                return;
            }

            if (x <= First.Info)
            {
                AddFirst(x);
            }

            var elem = First;
            while (elem.Next != null)
            {
                if (x <= elem.Info)
                {
                    var newElem = new Element() { Info = x, Next = elem };

                    return;
                }

                if (x > elem.Info && x > elem.Next.Info)
                {
                    elem = elem.Next;
                }

                else 
                {
                    var newelem = new Element { Info = x, Next = elem.Next };
                    elem.Next = newelem;

                    return;
                }
            }
            if (elem.Next == null) elem.Next = new Element { Info = x };
        }

        public void DeleteByIndex(int ind)
        {
            if (First == null)
                throw new ArgumentException();
            if (ind == 0)
                First = First.Next;
            else
            {
                var prevElem = First;
                for (int i = 1; i < ind; i++)
                {
                    prevElem = prevElem.Next;
                    if (prevElem == null)
                        throw new ArgumentException();
                }
                if (prevElem.Next != null) prevElem.Next = prevElem.Next.Next;
            }

        }

        public int Count()
        {
            var elem = First;
            int countInd = 1;
            if (elem == null) return 0;
            while (elem.Next != null)
            {
                elem = elem.Next;
                countInd++;
            }
            return countInd;
        }

        public int FindByValue(int x)
        {
            var elem = First;
            if (elem == null) throw new ArgumentOutOfRangeException();
            int index = 0;
            while (elem.Info != x)
            {
                if (elem == null) { throw new ArgumentOutOfRangeException(); }
                elem = elem.Next;
                index++;
            }
            return index;
        }

        public void AddLst(Element x)
        {

            if (First == null)
            {
                First = x;
                return;
            }
            var elem = First;
            while (elem.Next != null)
                elem = elem.Next;

            elem.Next = x;
        }

        public void DelFirst() {
            First = First.Next;
            this.deletion?.Invoke("Deleted from List data: ", First);
        }

        public void Clear(string ListName) {
            First = null; 
            this.deletionList?.Invoke("Deleted all data from List: ", ListName);
        }

        public static MySortedList ToUnite(MySortedList lst1, MySortedList lst2) 
        {
            MySortedList lst = new MySortedList();
            var elem1 = new Element { Info = lst1.First.Info, Next = lst1.First.Next };
            var elem2 = new Element { Info = lst2.First.Info, Next = lst2.First.Next };
            while(elem1 != null && elem2 != null)
            {
                if (elem1.Info < elem2.Info) { lst.AddLast(elem1.Info); elem1 = elem1.Next; }
                else if (elem1.Info == elem2.Info) { lst.AddLast(elem1.Info); elem1 = elem1.Next; elem2 = elem2.Next; }
                else { lst.AddLast(elem2.Info); elem2 = elem2.Next; }
            }

            if (elem1 != null && elem2 == null) { lst.AddLst(elem1); }

            else if (elem1 == null && elem2 != null) { lst.AddLst(elem2); }

            return lst; 
        }

        public static MySortedList ToIntersect(MySortedList lst1, MySortedList lst2)
        {
            MySortedList lst = new MySortedList();
            var elem1 = new Element { Info = lst1.First.Info, Next = lst1.First.Next };
            var elem2 = new Element { Info = lst2.First.Info, Next = lst2.First.Next };
            while (elem1 != null && elem2 != null)
            {
                if (elem1.Info < elem2.Info || elem1.Info > elem2.Info) 
                {
                    elem1 = elem1.Next;
                    elem2 = elem2.Next;
                } else if (elem1.Info == elem2.Info) // тут проверяем на равность
                {
                    lst.AddLast(elem2.Info);
                    elem2 = elem2.Next;
                    elem1 = elem1.Next;
                }

            }

            return lst;
        }

        public static MySortedList FindDiffrence(MySortedList lst1, MySortedList lst2) //в lst1 убирается всё, что есть в lst2
        {
            MySortedList lst = new MySortedList();
            var elem1 = new Element { Info = lst1.First.Info, Next = lst1.First.Next };
            var elem2 = new Element { Info = lst2.First.Info, Next = lst2.First.Next };
            while (elem1 != null && elem2 != null)
            {
                if (elem1.Info < elem2.Info) { lst.AddLast(elem1.Info); elem1 = elem1.Next; }

                // тут проверяем на равность
                else if (elem1.Info == elem2.Info) { elem1 = elem1.Next; elem2 = elem2.Next; }

                else elem2 = elem2.Next;

            }

            if (elem1 != null && elem2 == null) { lst.AddLst(elem1); }

            return lst;
        }

            public static void DisplayMessageClearList(string message, string ListName) {
            Console.Write(message);
            Console.WriteLine(ListName);
        }

        public static void DisplayMessage(string message, Element data) {
            Console.WriteLine(message);
            Console.WriteLine(data);
        }
    }
}