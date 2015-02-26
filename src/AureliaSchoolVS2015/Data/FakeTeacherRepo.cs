using System;
using System.Collections.Generic;
using System.Linq;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public class FakeTeacherRepo : ITeacherRepository
    {
        private List<Teacher> _teachers;

        public FakeTeacherRepo()
        {
            _teachers = new List<Teacher>
            {
                new Teacher {Id=1, Honorific="Dr.", FirstName="Janus", LastName="Porter", Email="jp@example.edu", Suffix="" },
                new Teacher {Id=2, Honorific="Mrs.", FirstName="Bertha", LastName="Bigguns", Email="bert@example.edu", Suffix="VC" },
                new Teacher {Id=3, Honorific="Dr.", FirstName="Miles", LastName="Standish", Email="miles@plymouth.edu", Suffix="KBE" }
            };
        }
        public void Delete(int id)
        {
            var rem = _teachers
               .Where(t => t.Id == id)
               .FirstOrDefault();
            _teachers.Remove(rem);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teachers;
        }

        public Teacher GetById(int id)
        {
            return _teachers
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }

        public void Insert(Teacher teacher)
        {
            var max = _teachers.Max(t => t.Id);
            max++;
            teacher.Id = max;
            _teachers.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            var old = _teachers
                .Where(t => t.Id == teacher.Id)
                .FirstOrDefault();
            if (old != null)
            {
                _teachers.Remove(old);
                _teachers.Add(teacher);
            }

        }
    }
}