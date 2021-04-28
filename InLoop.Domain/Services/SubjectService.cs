using InLoop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    class SubjectService
    {
        public async Task<List<Subject>> GetSubjects(CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<bool> AddSubject(Subject subject, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<List<Lecture>> GetLecturesForSubject(int subjectId, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<List<Student>> GetStudentsForSubject(int subjectId, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }
    }
}
