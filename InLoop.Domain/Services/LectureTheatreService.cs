using InLoop.Domain.Repository;
using InLoop.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InLoop.Domain.Services
{
    public class LectureTheatreService
    {
        private readonly IInLoopTestRepository _repository;

        public LectureTheatreService(IInLoopTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LectureTheatre>> GetLectureTheatresAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _repository.GetLectureTheatresAsync();
        }

        public async Task AddLectureTheatreAsync(LectureTheatre lectureTheatre, CancellationToken ct = default(CancellationToken))
        {
            await _repository.AddLectureTheatreAsync(lectureTheatre);
        }
    }
}
