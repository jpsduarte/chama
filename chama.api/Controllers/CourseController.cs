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

        public CourseController(ChamaContext chamaContext, ICourseService courseService)
        {
            _chamaContext = chamaContext;
            _courseService = courseService;
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

                bool first = true;
                int ages = 0, count = 0;

                foreach (var relation in map.CourseStudent)
                {
                    if (first)
                    {
                        map.MinimumAge = relation.Student.Age;
                        map.MaximumAge = relation.Student.Age;
                        first = false;
                    }

                    if(relation.Student.Age < map.MinimumAge)
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

                model.Add(map);
            }

            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] Course course)
        {
            //try to sign up to a course

            //get course
            var savedCourse = _courseService.GetByID(course.CourseId);

            if (savedCourse == null)
            {
                return NotFound("the course does not exists");
            }

            if(savedCourse.CourseStudent.Count == savedCourse.MaxSeats)
            {
                return BadRequest("the selected course is full");
            }

            //sign up student to a course
            //savedCourse.CourseStudent.Add(student);
            await _chamaContext.SaveChangesAsync();

            //The endpoint's response should indicate whether signing up was successful.
            //give the 200 response code
            return Ok("sign up successfully!");
        }
    }
}