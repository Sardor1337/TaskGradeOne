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
    public class StudentService: IStudentService
    {
        private readonly IAppDbContext _context;

        public StudentService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return new StudentViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Birthday = entity.Birthday,
                PhoneNumber = entity.PhoneNumber,

            };
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _context.Students
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Birthday = x.Birthday,
                    StudentRegisterNumber = x.StudentRegisterNumber
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity = new Student()
            {
                Name = model.Name,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Birthday = model.Birthday,
                Email = model.Email,
                StudentRegisterNumber= model.StudentRegisterNumber
                
            };

            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateStudentModel model)
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
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
