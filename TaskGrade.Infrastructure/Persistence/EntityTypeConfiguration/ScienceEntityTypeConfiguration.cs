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
    public class ScienceEntityTypeConfiguration : IEntityTypeConfiguration<Science>
    {
        public void Configure(EntityTypeBuilder<Science> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
