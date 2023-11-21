using AutoMapper;
using Demo.Academic.Entities;
using Demo.Academic.Protos;
using Demo.Academic.ViewModel;

namespace Demo.Academic.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseVM>().ReverseMap();
            CreateMap<Course, CourseResponse>().ReverseMap();
        }
    }
}
