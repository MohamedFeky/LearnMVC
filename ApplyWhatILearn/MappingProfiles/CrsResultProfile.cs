using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;

namespace ApplyWhatILearn.MappingProfiles
{
    public class CrsResultProfile : Profile
    {
        public CrsResultProfile()
        {
            CreateMap<CrsResult, ShowCrsResultViewModel>()
                   .ForMember(dest => dest.CourseName,
                              opt => opt.MapFrom(src => src.Course.Name))
                   .ForMember(dest => dest.TraineeName,
                              opt => opt.MapFrom(src => src.Trainee.Name))
                   .ForMember(dest => dest.Degree,
                              opt => opt.MapFrom(src => src.Degree))   
                   .ForMember(dest => dest.MinDegree,
                              opt => opt.MapFrom(src => src.Course.MinDegree)); 
        }
    }
}
