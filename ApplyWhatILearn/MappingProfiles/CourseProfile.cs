using AutoMapper;
using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;

namespace ApplyWhatILearn.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseCreateViewModel, Course>();
            CreateMap<Course, CourseCreateViewModel>();
        }
    }
}
