using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.api.Models;
using chama.domain.Entities;
using chama.domain.Exceptions;
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
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var courses = await _courseService.GetAllAsync();
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
        public async Task<ActionResult<CourseModel>> Get(int id)
        {
            var course = await _courseService.GetByIDAsync(id);

            if (course == null)
            {
                return NotFound("course does not exists");
            }

            var model = new CourseModel(course);
            GetCourseExtraInfo(course, model);

            return model;
        }

        private void GetCourseExtraInfo(Course course, CourseModel map)
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

        // POST api/course
        [HttpPost]
        public IActionResult SignUp([FromBody] int courseID, int studentID)
        {
            //try to sign up to a course

            try
            {
                _courseService.SignUp(courseID, studentID);

                //The endpoint's response should indicate whether signing up was successful.
                //give the 200 response code
                return Ok("sign up successfully!");
            }
            catch (Exception ex)
            {
                if (ex is CourseNotFoundException)
                {
                    return NotFound(ex.Message);
                }

                if (ex is CourseFullException || ex is StudentAlreadyOnCourseException)
                {
                    return BadRequest(ex.Message);
                }

                throw;
            }
        }

        // POST api/course
        [HttpPost]
        public async Task<IActionResult> SignUpAsync([FromBody] int courseID, int studentID)
        {
            //put the request on a queue
            //Redis, SQS on amazon

            //this task will be in sql server and then the chama.console will wait for requests

            var newTask = new Queue();
            newTask.CourseId = courseID;
            newTask.StudentId = studentID;

            await _chamaContext.AddAsync(newTask);
            await _chamaContext.SaveChangesAsync();

            return Ok("We have receveid your request and we will inform you by email!");
        }
    }
}