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
    public class GradeService : IGradeService
    {
        private readonly IAppDbContext _context;

        public GradeService(IAppDbContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(CreateGradeModel model)
        {
            var entity = new Grade()
            {
                ScienceId = model.ScienceId,
                StudentId = model.StudentId,
                TeacherId = model.TeacherId,
                GradePresent = model.GradePresent
            };

            _context.Grades.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Grades.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GradeViewModel>> GetAllAsync()
        {
            return await _context.Grades
                .Select(x => new GradeViewModel()
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    TeacherId = x.TeacherId,
                    GradePresent = x.GradePresent,
                    ScienceId = x.ScienceId,
                })
                .ToListAsync();
        }

        public async Task<GradeViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);

            return new GradeViewModel()
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                TeacherId = entity.TeacherId,
                ScienceId = entity.ScienceId,
                GradePresent = entity.GradePresent
            };
        }

        public async Task UpdateAsync(UpdateGradeModel model)
        {
            var entity = await _context.Grades.FirstOrDefaultAsync(x => x.Id == model.Id );

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.StudentId = model.StudentId ?? entity.StudentId;
            entity.TeacherId = model.TeacherId ?? entity.TeacherId;
            entity.ScienceId = model.ScienceId ?? entity.ScienceId;
            entity.GradePresent = model.GradePresent ?? entity.GradePresent;

            _context.Grades.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
