using AutoMapper;

namespace InLoop.DataLayer.Profiles
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<DataLayer.Models.Student, Domain.ViewModels.Student>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.StudentId));

            CreateMap<Domain.ViewModels.Student, DataLayer.Models.Student>()
                .ForMember(dest => dest.StudentId, opts => opts.MapFrom(src => src.Id));
        }
    }
}
