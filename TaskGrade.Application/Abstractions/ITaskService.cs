using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Models;

namespace TaskGrade.Application.Abstractions
{
    public interface ITaskService
    {
        Task<List<StudentViewModel>> GetAllYearsYoungStudentAsync(IntNumberModel overXyearsOldStudent);
        Task<List<StudentViewModel>> GetAllFromToMonthAsync(FromToMonthStudent fromToMonthStudent);
        Task<List<StudentViewModel>> GetAllYearsOldTeacherAsync(IntNumberModel overXyearsOldStudent);
        Task<List<StudentViewModel>> GetAllBeelineNumberAsync();
        Task<List<StudentViewModel>> GetAllNameContainsStudentAsync(NameContainsStudent nameContainsStudent);
        Task<string> GetMaxGradePresentScienseAsync(NameContainsStudent nameContainsStudent);
        Task<List<TeacherViewModel>> GetAllUpperGradeTeacherAsync();
        Task<Dictionary<string, string>> GetMaxGradeStudentsAsync();

    }
}
