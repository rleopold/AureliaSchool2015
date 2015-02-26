using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using AureliaSchoolVS2015.Data;
using AureliaSchoolVS2015.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AureliaSchoolVS2015.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private ITeacherRepository _teachers;

        public TeachersController(ITeacherRepository teachers)
        {
            _teachers = teachers;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _teachers.GetAll();
            return Json(teachers);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teacher = _teachers.GetById(id);
            if (teacher == null)
                return HttpNotFound();

            return Json(teacher);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Teacher value)
        {
            _teachers.Insert(value);
            return Json(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Teacher value)
        {
            value.Id = id;
            _teachers.Update(value);
            return new HttpStatusCodeResult(200);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teachers.Delete(id);
            return new HttpStatusCodeResult(200);
        }
    }
}
