using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent4.model
{
    internal class ElfPair
    {
        internal Section First { get; set; }
        internal Section Second { get; set; }

        internal bool Overlaped { get; set; }

        internal bool CheckIfOverlaped()
        {
            HashSet<int> first = CreateArray(First.Start, First.End).ToHashSet();
            HashSet<int> second = CreateArray(Second.Start, Second.End).ToHashSet();

            if (first.IsSubsetOf(second) || second.IsSubsetOf(first))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int[] CreateArray(int Start, int End)
        {
            List<int> array = new List<int>();
            int startCount = Start;

            while(startCount <= End)
            {
                array.Add(startCount);
                startCount++;
            }

            return array.ToArray();
        }
    }

    internal class Section
    {
        internal int Start { get; set; }
        internal int End { get; set; }
    }
}
