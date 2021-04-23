using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class LectureSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LectureScheduleId { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int LeatureId { get; set; }
        public Lecture Lecture { get; set; }

        public int LeatureTheatreId { get; set; }
        public LectureTheatre LectureTheatre { get; set; }
    }
}
