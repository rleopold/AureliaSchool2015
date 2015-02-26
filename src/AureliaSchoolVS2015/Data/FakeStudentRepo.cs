using System;
using System.Collections.Generic;
using System.Linq;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public class FakeStudentRepo : IStudentRepository
    {
        private List<Student> _students;

        public FakeStudentRepo()
        {
            _students = new List<Student>
            {
                new Student {Id= 1, FirstName="Richard", LastName="Leopold", Email="test1@example.com" },
                new Student {Id= 2, FirstName="Deke", LastName="Yablonkski", Email="test2@example.com" },
                new Student {Id= 3, FirstName="Chadwick", LastName="Bosworth", Email="test3@example.com"}
            };
        }
        public void Delete(int id)
        {
            var sstu = _students
                .Where(s => s.Id == id)
                .FirstOrDefault();
            _students.Remove(sstu);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public void Insert(Student student)
        {
            var max = _students.Max(s => s.Id);
            max++;
            student.Id = max;
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var old = _students
                .Where(s => s.Id == student.Id)
                .FirstOrDefault();
            if(old != null)
            {
                _students.Remove(old);
                _students.Add(student);
            }
        }
    }
}