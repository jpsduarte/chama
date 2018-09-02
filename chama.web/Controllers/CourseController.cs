using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.domain.Entities;
using chama.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace chama.web.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ChamaContext _chamaContext;
        private readonly ICourseService _courseService;

        public CourseController(ChamaContext chamaContext, ICourseService courseService)
        {
            _chamaContext = chamaContext;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var course = _chamaContext.Course.ToList();
            var courses = _courseService.GetAll();
            

            return View();
        }
    }
}
