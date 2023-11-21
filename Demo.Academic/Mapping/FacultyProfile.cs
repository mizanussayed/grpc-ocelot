using AutoMapper;
using Demo.Academic.Entities;
using Demo.Academic.ViewModel;

namespace Demo.Academic.Mapping
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, FacultyVM>().ReverseMap();
        }
    }
}
