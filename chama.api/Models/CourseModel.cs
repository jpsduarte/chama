using chama.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chama.api.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LecturerId { get; set; }
        public int MaxSeats { get; set; }

        public Lecturer Lecturer { get; set; }
        public ICollection<CourseStudent> CourseStudent { get; set; }

        //custom properties
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int AverageAge { get; set; }

        public CourseModel(Course course)
        {
            CourseId = course.CourseId;
            Name = course.Name;
            Description = course.Description;
            LecturerId = course.LecturerId;
            MaxSeats = course.MaxSeats;

            Lecturer = course.Lecturer;
            CourseStudent = course.CourseStudent;
        }
    }
}
