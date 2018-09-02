using System;
using System.Collections.Generic;

namespace chama.domain.Entities
{
    public partial class Queue
    {
        public int QueueId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
