using AutoMapper;
using System.Linq;

namespace InLoop.DataLayer.Profiles
{
    public class LectureProfile: Profile
    {
        public LectureProfile()
        {
            CreateMap<DataLayer.Models.Lecture, Domain.ViewModels.Lecture>()
                        .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.LectureId))
                        .ForMember(dest => dest.LectureTheatre, opts => opts.MapFrom(src => src.LectureSchedules.Select(ls => ls.LectureTheatre)));
        }
    }
}
