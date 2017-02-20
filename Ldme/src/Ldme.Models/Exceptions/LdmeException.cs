using System;

namespace Ldme.Models.Exceptions
{
    public class LdmeException : Exception
    {
        public LdmeException()
        {
        }

        public LdmeException(string message) : base(message)
        {
        }

        public LdmeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}