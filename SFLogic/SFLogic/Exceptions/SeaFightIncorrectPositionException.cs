using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLogic.Exceptions
{
    class SeaFightIncorrectPositionException : Exception
    {
        public SeaFightIncorrectPositionException()
        {
        }

        public SeaFightIncorrectPositionException(string message)
            : base(message)
        {
        }

        public SeaFightIncorrectPositionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
