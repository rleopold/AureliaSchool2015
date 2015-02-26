using System;
using System.Collections.Generic;
using System.Linq;
using AureliaSchoolVS2015.Models;

namespace AureliaSchoolVS2015.Data
{
    public class FakeClassRepo : IClassRepository
    {
        private List<Class> _classes;

        public FakeClassRepo()
        {
            _classes = new List<Class>
            {
                new Class { Id=1, Location="Holden Hall", Title="Stuffing 201", TeacherId=3 },
                new Class { Id=2, Location="Plymouth Commons", Title="History of Stuffing Wars", TeacherId=3 },
                new Class { Id=3, Location="Drake Hall", Title="How to be a Jackass", TeacherId=2 }
            };
        }

        public void Delete(int id)
        {
            var rem = _classes
               .Where(c => c.Id == id)
               .FirstOrDefault();
            _classes.Remove(rem);
        }

        public IEnumerable<Class> GetAll()
        {
            return _classes;
        }

        public Class GetById(int id)
        {
            return _classes
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void Insert(Class @class)
        {
            var max = _classes.Max(c => c.Id);
            max++;
            @class.Id = max;
            @class.TeacherId = @class.Teacher.Id; // just hack it for now...its a demo!
            _classes.Add(@class);
        }

        public void Update(Class @class)
        {
            var old = _classes
                .Where(c => c.Id == @class.Id)
                .FirstOrDefault();
            if (old != null)
            {
                _classes.Remove(old);
                _classes.Add(@class);
            }

        }
    }
}