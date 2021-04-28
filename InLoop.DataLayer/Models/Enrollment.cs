using System;
using System.Collections.Generic;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
