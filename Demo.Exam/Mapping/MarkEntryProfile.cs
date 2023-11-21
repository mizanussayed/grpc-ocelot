using AutoMapper;
using Demo.Exam.Entities;
using Demo.Exam.ViewModels;
using Demo.UserMgt.Protos;

namespace Demo.Exam.Mapping
{
    public class MarkEntryProfile : Profile
    {
        public MarkEntryProfile()
        {
            CreateMap<MarkEntry, MarkEntryVM>().ReverseMap();
            CreateMap<MarkEntry, MarkEntryRequest>().ReverseMap();
            CreateMap<MarkEntryVM, StudentResonse>().ReverseMap();
        }
    }
}
