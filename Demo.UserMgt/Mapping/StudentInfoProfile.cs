using AutoMapper;
using Demo.UserMgt.Entities;
using Demo.UserMgt.Protos;
using Demo.UserMgt.ViewModels;

namespace Demo.UserMgt.Mapping
{
    public class StudentInfoProfile : Profile
    {
        public StudentInfoProfile()
        {
            CreateMap<StudentInfo, StudentResonse>().ReverseMap();
            CreateMap<StudentInfo, StudentInfoVM>().ReverseMap();
        }
    }
}
