using System;
using System.Collections.Generic;
using System.Linq;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}