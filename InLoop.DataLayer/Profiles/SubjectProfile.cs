using AutoMapper;

namespace InLoop.DataLayer.Profiles
{
    public class SubjectProfile: Profile
    {
        public SubjectProfile()
        {
            CreateMap<DataLayer.Models.Subject, Domain.ViewModels.Subject>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.SubjectId));

            CreateMap<Domain.ViewModels.Subject, DataLayer.Models.Subject>()
                .ForMember(dest => dest.SubjectId, opts => opts.MapFrom(src => src.Id));
        }
    }
}
