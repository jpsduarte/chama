using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chama.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace chama.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            //try to sign up to a course

            return Ok();
        }

        [HttpPost]
        public IActionResult Post2([FromBody] Student student)
        {
            //send to a worker process

            return Ok();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
