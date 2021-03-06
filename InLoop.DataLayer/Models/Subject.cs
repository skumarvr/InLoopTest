using System;
using System.Collections.Generic;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LectureSchedule> LectureSchedules { get; set; } = new List<LectureSchedule>();
    }
}
