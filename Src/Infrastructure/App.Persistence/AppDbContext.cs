using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {               
        }
        public DbSet<Domain.Entities.Business> Businesses { get; set; } = default!;
        public DbSet<FootballField> FootballFields { get; set; } = default!;
        public DbSet<FieldSituation> FieldSituations { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Town> Towns { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<FootballField>()
                .ToTable("FootballFields", tb => tb.HasTrigger("trg_FootballFields_AllActions"));

            modelBuilder.Entity<Reservation>()
                .ToTable("Reservations", tb => tb.HasTrigger("trg_Reservations_AllActions"));

            modelBuilder.Entity<User>()
                .ToTable("Users", tb => tb.HasTrigger("trg_Users_AllActions"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
