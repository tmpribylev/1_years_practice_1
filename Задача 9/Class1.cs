﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_9
{
    class CircularListEntry
    {
        public int Value { get; set; }
        public int Key { get; set; } // в коллекции является, по сути, индексатором
        public CircularListEntry Next{ get; set; }
        public CircularListEntry()
        {
            Key = 0;
            Value = 0;
            Next = null;
        }
        public CircularListEntry(int value)
        {
            Value = value;
            Next = null;
        }
        public override string ToString()
        {
            return Convert.ToString(Value);
        }
        public void Show()
        {
            Console.WriteLine(ToString());
        }
    }

    class CircularList
    {
        public CircularListEntry First { get; set; }
        public int Count
        {
            get
            {
                int count = 0;
                if (First != null)
                {
                    CircularListEntry entry = First.Next;
                    count++;
                    while (entry.Key != First.Key)
                    {
                        count++;
                        entry = entry.Next;
                    }
                }
                return count;
            }
        }
        public CircularList()
        {
            First = null;
        }
        public CircularList(CircularListEntry first)
        {
            First = first;
        }
        public CircularList(ICollection<CircularListEntry> col)
        {
            CircularListEntry help = new CircularListEntry();
            First = help;
            foreach (CircularListEntry entry in col)
            {
                help.Value = entry.Value;
                help.Key = entry.Key;
                help.Next = new CircularListEntry();
                help = help.Next;
            }
            help.Next = First;

        }
        public CircularListEntry KeyFind(int key)
        {
            CircularListEntry help = First;
            if (key == help.Key) return help;
            help = help.Next;
            while (help.Key != First.Key) if (key == help.Key) return help;
                else help = help.Next;
            return null;
        }
        public void Remove(CircularListEntry entry)
        {
            if (First != null)
            {
                CircularListEntry help = First;
                if (help.Value != entry.Value)
                {
                    CircularListEntry last = help;
                    help = help.Next;
                    while (help.Key != First.Key)
                    {
                        if (help.Value == entry.Value)
                        {
                            last.Next = help.Next;
                            for (int i = help.Key; i < Count; i++)
                            {
                                help = help.Next;
                                help.Key = i;
                            }
                            break;
                        }
                        else
                        {
                            last = help;
                            help = help.Next;
                        }
                    }
                }
                else
                {
                    this.KeyFind(this.Count - 1).Next = help.Next;
                    First = help.Next;
                    for (int i = 0; i < Count; i++)
                    {
                        help = help.Next;
                        help.Key = i;
                    }
                }
            }
        }
        public void Add(CircularListEntry entry)
        {
            if (First != null)
            {
                CircularListEntry help = this.KeyFind(Count - 1);
                help.Next = entry;
                entry.Next = First;
                entry.Key = help.Key + 1;
            }
            else
            {
                First = entry;
                First.Key = 0;
                First.Next = First;
            }
        }
        public override string ToString()
        {
            if (First != null)
            {
                string ans = "";
                CircularListEntry help = First;
                ans += First.ToString() + " ";
                help = help.Next;
                while (help.Key != First.Key)
                {
                    ans += help.ToString() + " ";
                    help = help.Next;
                }
                return ans;
            }
            else return "Список пуст";
        }
        public void Show()
        {
            Console.WriteLine(ToString());
        }
    }
}
