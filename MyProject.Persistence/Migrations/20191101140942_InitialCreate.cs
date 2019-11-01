using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Discriminator", "LastUpdated", "Name", "Surname" },
                values: new object[] { new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"), new DateTime(2019, 11, 1, 15, 9, 42, 88, DateTimeKind.Local).AddTicks(6521), new DateTime(1980, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(5749), "Daniel", "Hoffman" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Discriminator", "LastUpdated", "Name", "Surname" },
                values: new object[] { new Guid("cb5358cf-7368-433c-a37b-b2d86ff34550"), new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6556), new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6570), "Albert", "Heisenower" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Discriminator", "LastUpdated", "Name", "Surname" },
                values: new object[] { new Guid("d4bee3e0-9a23-45fa-ad51-29daab009c4f"), new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6581), new DateTime(1960, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 11, 1, 15, 9, 42, 91, DateTimeKind.Local).AddTicks(6584), "Stephen", "King" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreationDate", "CustomerId", "Date", "Discriminator", "LastUpdated" },
                values: new object[,]
                {
                    { new Guid("e838f488-9281-4e32-9dcb-fe8be1c12df4"), new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1316), new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"), new DateTime(2019, 11, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(894) },
                    { new Guid("0840fff3-ff2d-4962-aaaa-b1813b5838f5"), new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1729), new Guid("0ab6c6dc-a4c7-4ce6-8094-eb304080dd38"), new DateTime(2019, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1720) },
                    { new Guid("d7861425-2876-48a5-82ea-b124f534e86a"), new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1738), new Guid("cb5358cf-7368-433c-a37b-b2d86ff34550"), new DateTime(2019, 10, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1736) },
                    { new Guid("0e90c6a6-ee13-4e76-8c33-da025b1ad5bd"), new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1744), new Guid("d4bee3e0-9a23-45fa-ad51-29daab009c4f"), new DateTime(2019, 12, 25, 18, 15, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 11, 1, 15, 9, 42, 95, DateTimeKind.Local).AddTicks(1742) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
