using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    internal class FormatException : Exception
    {
        public FormatException() { }

        public FormatException(string message) : base(message) { }
    }
}
