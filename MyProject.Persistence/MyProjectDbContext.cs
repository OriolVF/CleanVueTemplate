using System;
using System.Collections.Generic;
using System.Security.Principal;
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
            var customer1 = Guid.NewGuid();
            var customer2 = Guid.NewGuid();
            var customer3 = Guid.NewGuid();
            modelBuilder.Entity<SeedCustomer>()
                .HasData(new List<SeedCustomer>()
                {
                    new SeedCustomer()
                    {
                        Id = customer1,
                        Name = "Daniel",
                        Surname = "Hoffman",
                        DateOfBirth = new DateTime(1980, 3, 20),
                        CreationDate = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new SeedCustomer()
                    {
                        Id = customer2,
                        Name = "Albert",
                        Surname = "Heisenower",
                        DateOfBirth = new DateTime(1977, 9, 15),
                        CreationDate = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new SeedCustomer()
                    {
                        Id = customer3,
                        Name = "Stephen",
                        Surname = "King",
                        DateOfBirth = new DateTime(1960, 8, 5),
                        CreationDate = DateTime.Now,
                        LastUpdated = DateTime.Now
                    }
                });

            modelBuilder.Entity<SeedAppointment>()
                .HasData(new List<SeedAppointment>()
                {
                    new SeedAppointment()
                    {
                        CustomerId = customer1,
                        Date = new DateTime(2019, 11, 10, 9, 30, 0),
                        Id = Guid.NewGuid(),
                        LastUpdated = DateTime.Now,
                        CreationDate = DateTime.Now
                    },
                    new SeedAppointment()
                    {
                        CustomerId = customer1,
                        Date = new DateTime(2019, 10, 5, 15, 30, 0),
                        Id = Guid.NewGuid(),
                        LastUpdated = DateTime.Now,
                        CreationDate = DateTime.Now
                    },
                    
                    new SeedAppointment()
                    {
                        CustomerId = customer2,
                        Date = new DateTime(2019, 10, 31, 12, 30, 0),
                        Id = Guid.NewGuid(),
                        LastUpdated = DateTime.Now,
                        CreationDate = DateTime.Now
                    },
                    new SeedAppointment()
                    {
                        CustomerId = customer3,
                        Date = new DateTime(2019, 12, 25, 18, 15, 0),
                        Id = Guid.NewGuid(),
                        LastUpdated = DateTime.Now,
                        CreationDate = DateTime.Now
                    }
                });


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

    public class SeedCustomer : Customer
    {
        public DateTime LastUpdated { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class SeedAppointment : Appointment
    {
        public DateTime LastUpdated { get; set; }
        public DateTime CreationDate { get; set; }
    }
}