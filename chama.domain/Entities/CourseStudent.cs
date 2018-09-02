﻿using System;
using System.Collections.Generic;

namespace chama.domain.Entities
{
    public partial class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
