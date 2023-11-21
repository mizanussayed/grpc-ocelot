using AutoMapper;
using Demo.UserMgt.Data;
using Demo.UserMgt.Protos;
using Grpc.Core;
using static Demo.UserMgt.Protos.StudentData;

namespace Demo.UserMgt.GrpcServices
{
    public class StudentDataService(IStudentInfoRepository Repository, IMapper Mapper) : StudentDataBase
    {
        public override async Task<StudentListResponse> GetStudentDepartmentWise(StudentRequest request, ServerCallContext context)
        {
            var couseResult = Repository.GetAllAsync().Result.Where(d => d.DepartmentId == request.DepartmentId).ToList();
            var mappded = Mapper.Map<List<StudentResonse>>(couseResult);
            StudentListResponse returnList = new();
            returnList.StudentResonse.AddRange(mappded);
            await Task.Delay(0);
            return couseResult is null
                ? throw new RpcException(new Status(StatusCode.NotFound, "Student Not Found"))
                : returnList;
        }
    }
}
