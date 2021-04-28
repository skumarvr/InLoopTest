using System.Collections.Generic;

namespace InLoop.Domain.ViewModels
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LectureTheatre> LectureTheatre { get; set; }
    }
}
