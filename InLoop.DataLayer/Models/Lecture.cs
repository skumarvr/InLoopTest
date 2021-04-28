using System;
using System.Collections.Generic;
using System.Text;

namespace InLoop.DataLayer.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LectureSchedule> LectureSchedules { get; set; } = new List<LectureSchedule>();
    }

    // https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct?view=net-5.0
    // Custom comparer for the Lecture class
    public class LectureComparer : IEqualityComparer<Lecture>
    {
        // Lectures are equal if their names and Lecture numbers are equal.
        public bool Equals(Lecture x, Lecture y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the Lectures' properties are equal.
            return x.LectureId == y.LectureId;
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Lecture Lecture)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(Lecture, null)) return 0;

            //Get hash code for the LectureId field.
            int hashLectureId = Lecture.LectureId.GetHashCode();

            //Get hash code for the Name field if it is not null.
            int hashLectureName = Lecture.Name == null ? 0 : Lecture.Name.GetHashCode();

            //Calculate the hash code for the Lecture.
            return hashLectureName ^ hashLectureId;
        }
    }
}
