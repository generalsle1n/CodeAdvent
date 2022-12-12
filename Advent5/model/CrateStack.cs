using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent5.model
{
    internal class CrateStack
    {
        internal int ID { get; init; }
        internal CrateQueue Stack { get; set; }
    }
}
