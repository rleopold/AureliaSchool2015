using System;
using System.Collections.Generic;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAll();
        Class GetById(int id);
        void Insert(Class @class);
        void Update(Class @class);
        void Delete(int id);
    }
}