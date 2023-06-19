using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Models;

namespace TaskGrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("Student/age")]
        public async Task<IActionResult> GetOVerXYearsYoungStudentAll([FromQuery]IntNumberModel overXyearsOldStudent)
        {
            var result = await _taskService.GetAllYearsYoungStudentAsync(overXyearsOldStudent);

            return Ok(result);
        }

        [HttpGet("FromTo")]
        public async Task<IActionResult> GetFromToMonthAll([FromQuery] FromToMonthStudent fromToMonthStudent)
        {
            var result = await _taskService.GetAllFromToMonthAsync(fromToMonthStudent);

            return Ok(result);
        }

        [HttpGet("Teacher/age")]
        public async Task<IActionResult> GetOverXYearsOldTeacher([FromQuery] IntNumberModel overXyearsOldStudent)
        {
            var result = await _taskService.GetAllYearsOldTeacherAsync(overXyearsOldStudent);

            return Ok(result);
        }

        [HttpGet("Beeline")]
        public async Task<IActionResult> GetBeelineEmployees()
        {
            var result = await _taskService.GetAllBeelineNumberAsync();

            return Ok(result);
        }

        [HttpGet("NameContain")]
        public async Task<IActionResult> GetNameContains([FromQuery]NameContainsStudent nameContainsStudent)
        {
            var result = await _taskService.GetAllNameContainsStudentAsync(nameContainsStudent);

            return Ok(result);
        }

        [HttpGet("MaxPresent")]
        public async Task<IActionResult> GetMaxPresentStudent([FromQuery] NameContainsStudent nameContainsStudent)
        {
            var result = await _taskService.GetMaxGradePresentScienseAsync(nameContainsStudent);

            return Ok(result);
        }

        [HttpGet("97Upper")]
        public async Task<IActionResult> GetUpperGradeTeacher()
        {
            var result = await _taskService.GetAllUpperGradeTeacherAsync();

            return Ok(result);
        }

        [HttpGet("Upper/grade/sciense")]
        public async Task<IActionResult> GetMaxGradeSciense()
        {
            var result = await _taskService.GetMaxGradeStudentsAsync();

            return Ok(result);
        }
    }
}
