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
        public virtual Subject Subject { get; set; }

        public int LectureId { get; set; }
        public virtual Lecture Lecture { get; set; }

        public int LectureTheatreId { get; set; }
        public virtual LectureTheatre LectureTheatre { get; set; }
    }
}
