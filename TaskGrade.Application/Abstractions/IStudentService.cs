using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Models;

namespace TaskGrade.Application.Abstractions
{
    public interface IStudentService
    {
        Task<StudentViewModel> GetByIdAsync(int id);
        Task<List<StudentViewModel>> GetAllAsync();
        Task CreateAsync(CreateStudentModel model);
        Task UpdateAsync(UpdateStudentModel model);
        Task DeleteAsync(int id);
    }
}
