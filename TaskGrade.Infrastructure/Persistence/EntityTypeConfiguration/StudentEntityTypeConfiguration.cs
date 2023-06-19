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
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.Birthday).IsRequired();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.StudentRegisterNumber).IsRequired();
        }
    }
}
