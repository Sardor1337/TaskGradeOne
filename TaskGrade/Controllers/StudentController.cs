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

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateStudentModel model)
        {
            await _studentService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var teacher = await _studentService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _studentService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateStudentModel model)
        {
            await _studentService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok();
        }
    }
}
