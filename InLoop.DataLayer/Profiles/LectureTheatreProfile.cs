using AutoMapper;

namespace InLoop.DataLayer.Profiles
{
    public class LectureTheatreProfile: Profile
    {
        public LectureTheatreProfile()
        {
            CreateMap<DataLayer.Models.LectureTheatre, Domain.ViewModels.LectureTheatre>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.LectureTheatreId));

            CreateMap<Domain.ViewModels.LectureTheatre, DataLayer.Models.LectureTheatre>()
                .ForMember(dest => dest.LectureTheatreId, opts => opts.MapFrom(src => src.Id));
        }
    }
}
