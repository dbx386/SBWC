using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic
{
    class SeaFightException : Exception
    {
        public SeaFightException()
        {
        }

        public SeaFightException(string message)
            : base(message)
        {
        }

        public SeaFightException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
