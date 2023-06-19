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
    public class TeacherService : ITeacherService
    {
        private readonly IAppDbContext _context;

        public TeacherService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.UserRole == UserRole.Teacher);

            return new TeacherViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Birthday = entity.Birthday,
                PhoneNumber = entity.PhoneNumber,

            };
        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {
            return await _context.Users
                .Where(x => x.UserRole == UserRole.Teacher)
                .Select(x => new TeacherViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber  = x.PhoneNumber,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = new User()
            {
                Name = model.Name,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserRole = UserRole.Teacher,
                Birthday = model.Birthday,
                Email= model.Email,
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id && x.UserRole == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.PhoneNumber = model.PhoneNumber ?? entity.PhoneNumber;
            entity.Email = model.Email ?? entity.Email;

            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.UserRole == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
