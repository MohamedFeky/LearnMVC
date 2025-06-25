using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;

namespace ApplyWhatILearn.MappingProfiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<InstructorCreateViewModel, Instructor>();
            CreateMap<Instructor, InstructorCreateViewModel>();

        }
    }
}
