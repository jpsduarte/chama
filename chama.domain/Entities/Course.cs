﻿using System;
using System.Collections.Generic;

namespace chama.domain.Entities
{
    public partial class Course
    {
        public Course()
        {
            CourseStudent = new HashSet<CourseStudent>();
            Queue = new HashSet<Queue>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxSeats { get; set; }
        public int LecturerId { get; set; }

        public Lecturer Lecturer { get; set; }
        public ICollection<CourseStudent> CourseStudent { get; set; }
        public ICollection<Queue> Queue { get; set; }
    }
}
