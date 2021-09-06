using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.DestinationsFrom).WithOne(y => y.CityFrom).HasForeignKey(y => y.IdFrom).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.DestinationsTo).WithOne(y => y.CityTo).HasForeignKey(y => y.IdTo).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
