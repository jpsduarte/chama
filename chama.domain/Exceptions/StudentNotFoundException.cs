using System;
using System.Collections.Generic;
using System.Text;

namespace chama.domain.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException()
        {
        }

        public StudentNotFoundException(string message) : base(message)
        {
        }
    }
}
