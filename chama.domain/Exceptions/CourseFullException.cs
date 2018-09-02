using System;
using System.Collections.Generic;
using System.Text;

namespace chama.domain.Exceptions
{
    public class CourseFullException : Exception
    {   
        public CourseFullException()
        {
        }

        public CourseFullException(string message) : base(message)
        {
        }
    }
}
