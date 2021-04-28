using InLoop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    public class LectureTheatreService
    {
        public async Task<List<LectureTheatre>> GetLectureTheatres(CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }

        public async Task<bool> AddLectureTheatre(LectureTheatre lectureTheatre, CancellationToken ct = default(CancellationToken))
        {
            throw new Exception();
        }
    }
}
