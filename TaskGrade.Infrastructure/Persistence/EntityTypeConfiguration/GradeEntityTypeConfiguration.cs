using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Domain.Entities;

namespace TaskGrade.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class GradeEntityTypeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Teacher)
                .WithMany(p => p.Grades)
                .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.Science)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.ScienceId);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
