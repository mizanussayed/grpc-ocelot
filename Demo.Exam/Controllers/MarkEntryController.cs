using AutoMapper;
using Demo.Academic.Protos;
using Demo.Exam.Data;
using Demo.Exam.Entities;
using Demo.Exam.ViewModels;
using Demo.UserMgt.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkEntryController(IMarkEntryRepository Repository, IMapper Mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Repository.GetAllAsync();
            if (result is null)
            {
                return BadRequest();
            }
            using var channel = GrpcChannel.ForAddress("https://localhost:5013");
            var client = new StudentData.StudentDataClient(channel);
            var reply = await client.GetStudentDepartmentWiseAsync(
                              new StudentRequest { DepartmentId = 1 });
            var replyList = Mapper.Map<List<MarkEntryVM>>(reply.StudentResonse.ToList());

            var results = result.Join(replyList,
                    md => md.StudentId,
                    rl => rl.Id,  
                    (mk, std) => new { mk.Id, mk.StudentId, std.Name, mk.ObtainMark, mk.PassMark}).ToList();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Repository.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            var mappedData = Mapper.Map<MarkEntryVM>(result);
            using var channel = GrpcChannel.ForAddress("https://localhost:5011");
            var client = new CourseInfo.CourseInfoClient(channel);
            var reply = await client.GetCourseInfoAsync(
                              new CourseRequest { Id = result.CourseId });
            mappedData.Code = reply.Code;
            mappedData.Name = reply.Name;
            mappedData.DepartmentId = reply.DepartmentId;
            return Ok(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<MarkEntryRequest> model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var mappedData = Mapper.Map<List<MarkEntry>>(model);
                await Repository.CreateRangeAsync(mappedData);
                return Ok(mappedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] List<MarkEntryRequest> model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var mappdedData = Mapper.Map<List<MarkEntry>>(model);
                await Repository.UpdateRangeAsync(mappdedData);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Repository.GetAsync(id);
            if (result is null)
            {
                return BadRequest();
            }
            await Repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
