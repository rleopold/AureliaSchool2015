using System;
using System.Collections.Generic;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Insert(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}