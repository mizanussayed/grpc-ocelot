
using AutoMapper;
using Demo.Academic.Data;
using Demo.Academic.Protos;
using Grpc.Core;
using static Demo.Academic.Protos.CourseInfo;

namespace Demo.Academic.GrpcServices
{
    public class CourseInfoService(ICourseRepository Repository, IMapper Mapper) : CourseInfoBase
    {
        public override async Task<CourseResponse> GetCourseInfo(CourseRequest request, ServerCallContext context)
        {
            var couseResult = await Repository.GetAsync(request.Id);
            return couseResult is null
                ? throw new RpcException(new Status(StatusCode.NotFound, "Course Not Found"))
                : Mapper.Map<CourseResponse>(couseResult);
        }
    }
}
