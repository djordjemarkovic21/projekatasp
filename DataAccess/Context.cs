using DataAccess.Configuration;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3B9ERV0\SQLEXPRESS;Initial Catalog=Airlines2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            //modelBuilder.Entity<Like>().HasKey(x => new { x.IdPost, x.idUser });
            //modelBuilder.Entity<PostHashTag>().HasKey(x => new { x.IdPost, x.IdHashtag });


            modelBuilder.Entity<Country>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<City>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Destination>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Timetable>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Price>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Basket>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsActive = true;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            e.IsDeleted = false;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
