using AutoMapper;
using Demo.Academic.Data;
using Demo.Academic.Entities;
using Demo.Academic.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseRepository Repository, IMapper Mapper) : ControllerBase
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
        public async Task<IActionResult> Post([FromBody] CourseVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var mappedData = Mapper.Map<Course>(model);
                await Repository.CreateAsync(mappedData);
                return Ok(mappedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseVM model)
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
                result.Id = id;
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
