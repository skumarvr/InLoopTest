using AutoMapper;
using InLoop.Domain.Repository;
using InLoop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    public class StudentService
    {
        private readonly IInLoopTestRepository _repository;

        public StudentService(IInLoopTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetStudentsAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetStudentsAsync();
        }

        public async Task AddStudentAsync(Student student, CancellationToken ct = default(CancellationToken))
        {
            await _repository.AddStudentAsync(student);
        }

        public async Task<List<Subject>> GetEnrolmentsForStudentAsync(int studentId, CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetEnrolmentsForStudentAsync(studentId);
        }
    }
}
