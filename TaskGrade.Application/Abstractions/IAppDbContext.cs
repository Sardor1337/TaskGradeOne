using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Domain.Entities;

namespace TaskGrade.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Science> Sciences { get; set; }
        DbSet<Grade> Grades { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
