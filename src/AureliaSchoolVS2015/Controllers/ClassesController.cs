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
    public class ClassesController : Controller
    {
        private IClassRepository _classes;
        private ITeacherRepository _teachers;

        public ClassesController(IClassRepository classes, ITeacherRepository teachers)
        {
            _classes = classes;
            _teachers = teachers;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var classes = _classes.GetAll();
            foreach(var c in classes)
            {
                if(c.Teacher == null)
                    c.Teacher = _teachers.GetById(c.TeacherId); //hack...it's a demo!
            }
            return Json(classes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var @class = _classes.GetById(id);
            if (@class == null)
                return HttpNotFound();

            return Json(@class);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Class value)
        {
            _classes.Insert(value);
            return Json(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Class value)
        {
            value.Id = id;
            _classes.Update(value);
            return new HttpStatusCodeResult(200);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _classes.Delete(id);
            return new HttpStatusCodeResult(200);
        }
    }
}
