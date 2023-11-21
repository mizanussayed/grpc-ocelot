using AutoMapper;
using Demo.Academic.Protos;
using Demo.Exam.Data;
using Demo.Exam.Entities;
using Demo.Exam.ViewModels;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamSetupController(IExamSetupRepository Repository, IMapper Mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Repository.GetAllAsync();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Repository.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            var mappedData = Mapper.Map<ExamSetupVM>(result);
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
        public async Task<IActionResult> Post([FromBody] ExamSetupRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var mappedData = Mapper.Map<ExamSetup>(model);
                await Repository.CreateAsync(mappedData);
                return Ok(mappedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExamSetupRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await Repository.GetAsync(id);
                if (result is null)
                {
                    return NotFound();
                }
                result.CourseId = model.CourseId;
                result.Duration = model.Duration;
                result.CenterName = model.CenterName;
                result.ExamDate = model.ExamDate;
                await Repository.UpdateAsync(result);
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
