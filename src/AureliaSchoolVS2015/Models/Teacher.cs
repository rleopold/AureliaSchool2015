using System;

namespace AureliaSchoolVS2015.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Honorific { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
    }
}