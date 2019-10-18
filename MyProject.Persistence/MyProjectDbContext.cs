using System;
using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Persistence
{
    public class MyProjectDbContext : DbContext
    {
        public MyProjectDbContext()
        {

        }

        public MyProjectDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Customer>()
                .Property<DateTime>("CreationDate");

            modelBuilder.Entity<Appointment>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Appointment>()
                .Property<DateTime>("CreationDate");
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}