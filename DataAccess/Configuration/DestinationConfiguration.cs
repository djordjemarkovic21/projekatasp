using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.Property(x => x.Duration).IsRequired();


           builder.HasMany(x => x.Timetables).WithOne(y => y.Destination).HasForeignKey(y => y.IdDestination);
        }
    }
}
