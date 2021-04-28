using InLoop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    public class StudentService
    {
        public async Task<List<Student>> GetStudents(CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<bool> AddStudent(Student student, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<List<Subject>> GetEnrolmentsForStudent(int studentId, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }
    }
}
