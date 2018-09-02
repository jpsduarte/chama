using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.api.Models;
using chama.domain.Entities;
using chama.domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chama.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ChamaContext _chamaContext;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public CourseController(ChamaContext chamaContext, 
            ICourseService courseService, 
            IStudentService studentService)
        {
            _chamaContext = chamaContext;
            _courseService = courseService;
            _studentService = studentService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var courses = _courseService.GetAll();
            var model = new List<CourseModel>();

            foreach (var course in courses)
            {
                //Here I could use the AutoMapper library. 
                //but for time purposes I will do it manually.
                //Auto mapper needs a bit of configuration

                var map = new CourseModel(course);

                GetCourseExtraInfo(course, map);

                model.Add(map);
            }

            return Ok(model);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CourseModel> Get(int id)
        {
            var course = _courseService.GetByID(id);

            if(course == null)
            {
                return NotFound("course does not exists");
            }

            var model = new CourseModel(course);
            GetCourseExtraInfo(course, model);

            return model;
        }

        private static void GetCourseExtraInfo(Course course, CourseModel map)
        {
            bool first = true;
            int ages = 0, count = 0;

            foreach (var relation in course.CourseStudent)
            {
                if (first)
                {
                    map.MinimumAge = relation.Student.Age;
                    map.MaximumAge = relation.Student.Age;
                    first = false;
                }

                if (relation.Student.Age < map.MinimumAge)
                {
                    map.MinimumAge = relation.Student.Age;
                }

                if (relation.Student.Age > map.MaximumAge)
                {
                    map.MaximumAge = relation.Student.Age;
                }

                ages += relation.Student.Age;
                count++;
            }

            if (count > 0)
            {
                map.AverageAge = ages / count;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] int courseID, [FromBody] int studentID)
        {
            //try to sign up to a course

            //get course
            var savedCourse = _courseService.GetByID(courseID);

            if (savedCourse == null)
            {
                return NotFound("The course does not exists");
            }

            if(savedCourse.CourseStudent.Count == savedCourse.MaxSeats)
            {
                return BadRequest("The selected course is full. Please, select another one.");
            }

            //check if student isn't already in this course
            if(savedCourse.CourseStudent.Any(i=> i.StudentId == studentID))
            {
                return BadRequest("The selected student is already on this course. Please, select another one.");
            }

            //get student
            var savedStudent = _studentService.GetByID(studentID);

            if(savedStudent == null)
            {
                return NotFound("The selected student does not exists");
            }

            var newStudent = new CourseStudent();
            newStudent.CourseId = courseID;
            newStudent.StudentId = studentID;

            //sign up student to a course
            savedCourse.CourseStudent.Add(newStudent);
           
            //save changes
            await _chamaContext.SaveChangesAsync();

            //The endpoint's response should indicate whether signing up was successful.
            //give the 200 response code
            return Ok("sign up successfully!");
        }
    }
}