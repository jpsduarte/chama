﻿using System;
using System.Collections.Generic;

namespace chama.web.Entities
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

        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
