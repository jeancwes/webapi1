using System;

namespace WebApi1.Models 
{
    class ClientBornDateInvalidException : Exception
    {
        public ClientBornDateInvalidException(string message)
        {
        }
    }
}
