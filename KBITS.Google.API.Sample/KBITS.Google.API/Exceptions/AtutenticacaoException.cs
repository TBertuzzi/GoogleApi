using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBITS.Google.API.Exceptions
{
    public class AtutenticacaoException : Exception
    {
        public AtutenticacaoException()
        {
        }

        public AtutenticacaoException(string message)
        : base(message)
        {
        }

        public AtutenticacaoException(string message, Exception inner)
        : base(message, inner)
        {
        }

    }
}
