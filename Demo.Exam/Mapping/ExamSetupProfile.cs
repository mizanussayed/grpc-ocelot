using AutoMapper;
using Demo.Exam.Entities;
using Demo.Exam.ViewModels;

namespace Demo.Exam.Mapping
{
    public class ExamSetupProfile : Profile
    {
        public ExamSetupProfile()
        {
            CreateMap<ExamSetup, ExamSetupRequest>().ReverseMap();
            CreateMap<ExamSetup, ExamSetupVM>().ReverseMap();
        }
    }
}
