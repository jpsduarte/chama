using System;
using System.Collections.Generic;

namespace chama.web.Entities
{
    public partial class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
