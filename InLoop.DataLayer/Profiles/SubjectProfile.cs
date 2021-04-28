using AutoMapper;

namespace InLoop.DataLayer.Profiles
{
    public class SubjectProfile: Profile
    {
        public SubjectProfile()
        {
            CreateMap<DataLayer.Models.Subject, Domain.ViewModels.Subject>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.SubjectId));
        }
    }
}
