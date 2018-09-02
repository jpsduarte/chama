using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.domain.Entities;
using chama.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace chama.web.Controllers
{
    public class LecturerController : BaseController
    {
        private readonly ChamaContext _chamaContext;
        private readonly ILecturerService _lecturerService;

        public LecturerController(ChamaContext chamaContext, ILecturerService lecturerService)
        {
            _chamaContext = chamaContext;
            _lecturerService = lecturerService;
        }

        public IActionResult Index()
        {
            var lecturer = _chamaContext.Lecturer.ToList();
            var lectureres = _lecturerService.GetAll();



            return View();
        }
    }
}
