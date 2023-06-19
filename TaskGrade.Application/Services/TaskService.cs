using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Application.Abstractions;
using TaskGrade.Application.Models;
using TaskGrade.Domain.Enums;

namespace TaskGrade.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IAppDbContext _context;

        public TaskService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentViewModel>> GetAllBeelineNumberAsync()
        {
            return await _context.Students
                .Where(s => s.PhoneNumber.Contains("+99891") || s.PhoneNumber.Contains("+99890"))
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetAllFromToMonthAsync(FromToMonthStudent fromToMonthStudent)
        {
            return await _context.Students
                .Where(x => x.Birthday.Month >= fromToMonthStudent.FromMonth && x.Birthday.Month <= fromToMonthStudent.ToMonth)
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email= x.Email,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetAllNameContainsStudentAsync(NameContainsStudent nameContainsStudent)
        {
            return await _context.Students
                .Where(x => x.Name.Contains(nameContainsStudent.Name) || x.LastName.Contains(nameContainsStudent.Name))
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task<List<TeacherViewModel>> GetAllUpperGradeTeacherAsync()
        {
            List<int> ints= new List<int>();
            foreach (var item in _context.Grades)
            {
                if(item.GradePresent > 97)
                {
                    ints.Add(item.TeacherId);
                }
            }
            List<int> noDubl = ints.Distinct().ToList();

            List<TeacherViewModel> teacherViewModel = new List<TeacherViewModel>();

            foreach (var item in noDubl)
            {
                foreach (var teacher in _context.Users)
                {
                    if(item == teacher.Id)
                    {
                        teacherViewModel.Add( new TeacherViewModel()
                        {
                            Name = teacher.Name,
                            LastName = teacher.LastName,
                            PhoneNumber = teacher.PhoneNumber,
                            Email = teacher.Email,
                            Birthday = teacher.Birthday
                        });
                    }
                }
            }

            return teacherViewModel;
        }

        public async Task<List<StudentViewModel>> GetAllYearsOldTeacherAsync(IntNumberModel overXyearsOldStudent)
        {
            return await _context.Users
                .Where(x => x.Birthday.Year <= (DateTime.Now.Year - overXyearsOldStudent.Age))
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetAllYearsYoungStudentAsync(IntNumberModel overXyearsOldStudent)
        {
            return await _context.Students
                .Where(x => x.Birthday.Year >= (DateTime.Now.Year - overXyearsOldStudent.Age))
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Birthday = x.Birthday,
                })
                .ToListAsync();
        }

        public async Task<string> GetMaxGradePresentScienseAsync(NameContainsStudent nameContainsStudent)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Name == nameContainsStudent.Name);

            if (student == null)
            {
                throw new Exception("Not found");
            }

            int id = 0;
            int maxGradePresent = 0;
            foreach (var item in _context.Grades)
            {
                if(item.GradePresent > maxGradePresent && item.Id == student.Id)
                {
                    id = item.ScienceId;
                    maxGradePresent = item.GradePresent;
                }
            }

            foreach (var item in _context.Sciences)
            {
                if(item.Id == id)
                {
                    return item.Name;
                }
            }
            return "not found";
        }

        public Task<Dictionary<string, string>> GetMaxGradeStudentsAsync()
        {
            Dictionary<string, string> keyValues= new Dictionary<string, string>();

            int maxpresent = 0;
            string studentName = "";
            string scienseName = "";
            foreach (var student in _context.Students)
            {
                foreach (var item in _context.Grades)
                {
                    if(item.GradePresent > maxpresent && item.Id == student.Id)
                    {
                        maxpresent = item.GradePresent;
                        studentName = student.Name;
                        scienseName = item.Science.Name; 
                        break;
                    }
                }
                keyValues.Add(studentName, scienseName);
            }

            return Task.FromResult(keyValues);
        }
    }
}
