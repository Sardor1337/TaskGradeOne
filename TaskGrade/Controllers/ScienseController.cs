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
    public class ScienseController : ControllerBase
    {
        private readonly IScienseService _scienseService;

        public ScienseController(IScienseService scienseService)
        {
            _scienseService = scienseService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] CreateScienseModel model)
        {
            await _scienseService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var teacher = await _scienseService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _scienseService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateScienceModel model)
        {
            await _scienseService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _scienseService.DeleteAsync(id);

            return Ok();
        }
    }
}
