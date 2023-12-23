using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent5.model
{
    internal class CrateQueue
    {
        private List<Crate> allCrates = new List<Crate>();

        internal void AddCrate(Crate crate)
        {
            allCrates.Add(crate);
        }

        internal Crate GetCrate()
        {
            Crate current = allCrates.Last();
            allCrates.RemoveAt(allCrates.Count - 1);
            return current;
        }
    }
}
