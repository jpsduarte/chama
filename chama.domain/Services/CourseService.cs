using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.domain.Entities;
using chama.domain.Exceptions;
using chama.domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chama.domain.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        private ChamaContext _chamaContext;

        public CourseService(ChamaContext chamaContext) : base(chamaContext)
        {
            _chamaContext = chamaContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _chamaContext.Course
                .Include(i => i.Lecturer)
                .Include(i => i.CourseStudent)
                .ToListAsync();
        }

        public async Task<Course> GetByIDAsync(int id)
        {
            return await _chamaContext.Course
                .Include(i => i.Lecturer)
                .Include(i => i.CourseStudent)
                .FirstOrDefaultAsync(i => i.CourseId == id);
        }

        public void SignUp(int courseID, int studentID)
        {
            //get course
            var savedCourse = this.GetByID(courseID);

            if (savedCourse == null)
            {
                throw new CourseNotFoundException("The course does not exists");
            }

            if (savedCourse.CourseStudent.Count == savedCourse.MaxSeats)
            {
                throw new CourseFullException("The selected course is full. Please, select another one.");
            }

            //check if student isn't already in this course
            if (savedCourse.CourseStudent.Any(i => i.StudentId == studentID))
            {
                throw new StudentAlreadyOnCourseException("The selected student is already on this course. Please, select another one.");
            }

            //get student
            var savedStudent = this.GetByID(studentID);

            if (savedStudent == null)
            {
                throw new StudentNotFoundException("The selected student does not exists");
            }

            var newStudent = new CourseStudent();
            newStudent.CourseId = courseID;
            newStudent.StudentId = studentID;

            //sign up student to a course
            savedCourse.CourseStudent.Add(newStudent);

            //save changes
            _chamaContext.SaveChanges();
        }
    }
}