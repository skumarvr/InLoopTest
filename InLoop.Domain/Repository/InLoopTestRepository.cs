using InLoop.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Repository
{
    public interface IInLoopTestRepository
    {
        Task<List<Student>> GetStudentsAsync(CancellationToken ct = default(CancellationToken));
        Task AddStudentAsync(Student student, CancellationToken ct = default(CancellationToken));
        Task<List<Subject>> GetSubjectsAsync(CancellationToken ct = default(CancellationToken));
        Task AddSubjectAsync(Subject subject, CancellationToken ct = default(CancellationToken));
        Task<List<LectureTheatre>> GetLectureTheatresAsync(CancellationToken ct = default(CancellationToken));
        Task AddLectureTheatreAsync(LectureTheatre lectureTheatre, CancellationToken ct = default(CancellationToken));
        Task<List<Lecture>> GetLecturesForSubjectAsync(int subjectId, CancellationToken ct = default(CancellationToken));
        Task<List<Subject>> GetEnrolmentsForStudentAsync(int studentId, CancellationToken ct = default(CancellationToken));
        Task<List<Student>> GetStudentsForSubjectAsync(int subjectId, CancellationToken ct = default(CancellationToken));
    }
}
