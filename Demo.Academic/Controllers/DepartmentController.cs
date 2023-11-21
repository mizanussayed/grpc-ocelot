using AutoMapper;
using Demo.Academic.Data;
using Demo.Academic.Entities;
using Demo.Academic.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentRepository Repository, IMapper Mapper) : ControllerBase
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
        public async Task<IActionResult> Post([FromBody] DepartmentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var mappedData = Mapper.Map<Department>(model);
                await Repository.CreateAsync(mappedData);
                return Ok(mappedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentVM model)
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
                result.Id = id;
                result.Name = model.Name;
                result.Code = model.Code;
                result.Description = model.Description;
                result.FacultyId = model.FacultyId;
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
