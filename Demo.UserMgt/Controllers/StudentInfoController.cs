using AutoMapper;
using Demo.UserMgt.Data;
using Demo.UserMgt.Entities;
using Demo.UserMgt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.UserMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController(IStudentInfoRepository Repository, IMapper Mapper) : ControllerBase
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
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentInfoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var mappedData = Mapper.Map<StudentInfo>(model);
                await Repository.CreateAsync(mappedData);
                return Ok(mappedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentInfoVM model)
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
                result.Name = model.Name;
                result.Email = model.Email;
                result.MobileNumber = model.MobileNumber;
                result.DepartmentId = model.DepartmentId;
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
