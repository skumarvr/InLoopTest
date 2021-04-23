using System;
using System.Collections.Generic;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<Enrollment> Posts { get; } = new List<Enrollment>();
    }
}
