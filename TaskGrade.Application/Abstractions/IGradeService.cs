using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Models;

namespace TaskGrade.Application.Abstractions
{
    public interface IGradeService
    {
        Task<GradeViewModel> GetByIdAsync(int id);
        Task<List<GradeViewModel>> GetAllAsync();
        Task CreateAsync(CreateGradeModel model);
        Task UpdateAsync(UpdateGradeModel model);
        Task DeleteAsync(int id);
    }
}
