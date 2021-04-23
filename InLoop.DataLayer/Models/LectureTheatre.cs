using System;
using System.Collections.Generic;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class LectureTheatre
    {
        public int LectureTheatreId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<LectureSchedule> LectureSchedules { get; } = new List<LectureSchedule>();
    }
}
