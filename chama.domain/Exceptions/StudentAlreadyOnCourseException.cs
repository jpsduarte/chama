using System;
using System.Collections.Generic;
using System.Text;

namespace chama.domain.Exceptions
{
    public class StudentAlreadyOnCourseException : Exception
    {
        public StudentAlreadyOnCourseException()
        {
        }

        public StudentAlreadyOnCourseException(string message) : base(message)
        {
        }
    }
}
