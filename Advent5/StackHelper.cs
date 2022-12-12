using Advent5.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent5
{
    internal class StackHelper
    {
        internal List<CrateStack> CreateStacks(string IDLine)
        {
            List<CrateStack> result = new List<CrateStack>();

            string[] allIDs = IDLine.Split("   ");
            foreach (string ID in allIDs)
            {
                result.Add(new CrateStack()
                {
                    ID = int.Parse(ID.Replace(" ", "")),
                    Stack = new CrateQueue()
                });
            }

            return result;
        }
        internal string[] SplitLineIntoCrate(string crates)
        {
            List<string> result = new List<string>();

            int start = 0;
            int spaces = 3;

            while (start <= crates.Length)
            {
                string rawCrate = crates.Substring(start, spaces);
                rawCrate = rawCrate.Replace("[", "").Replace("]", "");
                result.Add(rawCrate);
                start += 4;
            }

            return result.ToArray();
        }
    }
}
