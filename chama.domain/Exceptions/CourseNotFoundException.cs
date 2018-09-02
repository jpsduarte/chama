using System;
using System.Collections.Generic;
using System.Text;

namespace chama.domain.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException()
        {
        }

        public CourseNotFoundException(string message) : base(message)
        {

        }
    }
}
