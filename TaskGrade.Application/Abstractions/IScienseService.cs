using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Models;

namespace TaskGrade.Application.Abstractions
{
    public interface IScienseService
    {
        Task<ScienseViewModel> GetByIdAsync(int id);
        Task<List<ScienseViewModel>> GetAllAsync();
        Task CreateAsync(CreateScienseModel model);
        Task UpdateAsync(UpdateScienceModel model);
        Task DeleteAsync(int id);
    }
}
