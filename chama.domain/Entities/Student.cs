using System;
using System.Collections.Generic;

namespace chama.domain.Entities
{
    public partial class Student
    {
        public Student()
        {
            CourseStudent = new HashSet<CourseStudent>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
