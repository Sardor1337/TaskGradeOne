using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Models;

namespace TaskGrade.Application.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GetByIdAsync(int id);
        Task<List<TeacherViewModel>> GetAllAsync();
        Task CreateAsync(CreateTeacherModel model);
        Task UpdateAsync(UpdateTeacherModel model);
        Task DeleteAsync(int id);
    }
}
