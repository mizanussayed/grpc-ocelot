using AutoMapper;
using Demo.Academic.Entities;
using Demo.Academic.ViewModel;

namespace Demo.Academic.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentVM>().ReverseMap();
        }
    }
}
