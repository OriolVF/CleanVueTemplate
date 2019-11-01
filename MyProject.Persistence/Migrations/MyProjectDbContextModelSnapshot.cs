﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.Persistence;

namespace MyProject.Persistence.Migrations
{
    [DbContext(typeof(MyProjectDbContext))]
    partial class MyProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyProject.Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Appointment");
                });

            modelBuilder.Entity("MyProject.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");
                });

            modelBuilder.Entity("MyProject.Persistence.SeedAppointment", b =>
                {
                    b.HasBaseType("MyProject.Domain.Entities.Appointment");

                    b.HasDiscriminator().HasValue("SeedAppointment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e838f488-9281-4e32-9dcb-fe8be1c12df4"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1316),
                            CustomerId = new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"),
                            Date = new DateTime(2019, 11, 10, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(894)
                        },
                        new
                        {
                            Id = new Guid("0840fff3-ff2d-4962-aaaa-b1813b5838f5"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1729),
                            CustomerId = new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"),
                            Date = new DateTime(2019, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1720)
                        },
                        new
                        {
                            Id = new Guid("d7861425-2876-48a5-82ea-b124f534e86a"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1738),
                            CustomerId = new Guid("cb5358cf-7368-433c-a37b-b2d86ff34550"),
                            Date = new DateTime(2019, 10, 31, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1736)
                        },
                        new
                        {
                            Id = new Guid("0e90c6a6-ee13-4e76-8c33-da025b1ad5bd"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1744),
                            CustomerId = new Guid("d4bee3e0-9a23-45fa-ad51-29daab009c4f"),
                            Date = new DateTime(2019, 12, 25, 18, 15, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1742)
                        });
                });

            modelBuilder.Entity("MyProject.Persistence.SeedCustomer", b =>
                {
                    b.HasBaseType("MyProject.Domain.Entities.Customer");

                    b.HasDiscriminator().HasValue("SeedCustomer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 88, DateTimeKind.Local).AddTicks(6521),
                            DateOfBirth = new DateTime(1980, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(5749),
                            Name = "Daniel",
                            Surname = "Hoffman"
                        },
                        new
                        {
                            Id = new Guid("cb5358cf-7368-433c-a37b-b2d86ff34550"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6556),
                            DateOfBirth = new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6570),
                            Name = "Albert",
                            Surname = "Heisenower"
                        },
                        new
                        {
                            Id = new Guid("d4bee3e0-9a23-45fa-ad51-29daab009c4f"),
                            CreationDate = new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6581),
                            DateOfBirth = new DateTime(1960, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6584),
                            Name = "Stephen",
                            Surname = "King"
                        });
                });

            modelBuilder.Entity("MyProject.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("MyProject.Domain.Entities.Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
