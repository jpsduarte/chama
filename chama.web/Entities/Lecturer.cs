using System;
using System.Collections.Generic;

namespace chama.web.Entities
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Course = new HashSet<Course>();
        }

        public int LecturerId { get; set; }
        public string Name { get; set; }

        public ICollection<Course> Course { get; set; }
    }
}
