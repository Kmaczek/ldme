using System;

namespace Ldme.Models.Exceptions
{
    public class ResourceNotFoundException : LdmeException
    {
        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}