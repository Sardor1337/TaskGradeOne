using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Models;
using TaskGrade.Domain.Entities;
using TaskGrade.Domain.Enums;

namespace TaskGrade.Application.Services
{
    public class ScienseService : IScienseService
    {
        private readonly IAppDbContext _context;

        public ScienseService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateScienseModel model)
        {
            var entity = new Science()
            {
                Name = model.Name
            };

            _context.Sciences.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Sciences.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Sciences.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScienseViewModel>> GetAllAsync()
        {
            return await _context.Sciences
                .Select(x => new ScienseViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }

        public async Task<ScienseViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Sciences.FirstOrDefaultAsync(x => x.Id == id);

            return new ScienseViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task UpdateAsync(UpdateScienceModel model)
        {
            var entity = await _context.Sciences.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.Name = model.Name ?? entity.Name;

            _context.Sciences.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
