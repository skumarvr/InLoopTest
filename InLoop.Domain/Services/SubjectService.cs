using AutoMapper;
using InLoop.Domain.Repository;
using InLoop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    public class SubjectService
    {
        private readonly IInLoopTestRepository _repository;

        public SubjectService(IInLoopTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subject>> GetSubjectsAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetSubjectsAsync();
        }

        public async Task AddSubjectAsync(Subject subject, CancellationToken ct = default(CancellationToken))
        {
            await _repository.AddSubjectAsync(subject);
        }

        public async Task<List<Lecture>> GetLecturesForSubjectAsync(int subjectId, CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetLecturesForSubjectAsync(subjectId);
        }

        public async Task<List<Student>> GetStudentsForSubjectAsync(int subjectId, CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetStudentsForSubjectAsync(subjectId);
        }
    }
}
