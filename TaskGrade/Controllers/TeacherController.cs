using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Models;

namespace TaskGrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateTeacherModel model)
        {
            await _teacherService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateTeacherModel model)
        {
            await _teacherService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok();
        }
    }
}
