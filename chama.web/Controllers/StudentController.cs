using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chama.web.Models;
using chama.domain.Entities;
using chama.domain.Interfaces;

namespace chama.web.Controllers
{
    public class StudentController : BaseController
    {
        private readonly ChamaContext _chamaContext;
        private readonly IStudentService _studentService;

        public StudentController(ChamaContext chamaContext, IStudentService studentService)
        {
            _chamaContext = chamaContext;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _chamaContext.Student.ToList();
            var studentss = _studentService.GetAll();


            return View();
        }        
    }
}
