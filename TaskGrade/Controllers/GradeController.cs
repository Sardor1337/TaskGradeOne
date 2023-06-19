using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Models;

namespace TaskGrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateGradeModel model)
        {
            await _gradeService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var teacher = await _gradeService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _gradeService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateGradeModel model)
        {
            await _gradeService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _gradeService.DeleteAsync(id);

            return Ok();
        }
    }
}
