using System;

namespace AureliaSchoolVS2015.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}