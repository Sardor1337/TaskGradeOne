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
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.Birthday).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.HasData(new User()
            {
                Id = 1,
                Name = "Sardor",
                LastName = "Rustamov",
                Birthday = new DateTime(),
                Email = "admin@gmail.com",
                UserRole = Domain.Enums.UserRole.Admin,
                PhoneNumber = "+998931441337"
            });



        }
    }
}
