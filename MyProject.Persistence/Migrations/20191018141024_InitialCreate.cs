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
                values: new object[] { new Guid("971f3745-fc7b-465a-9984-7c72747480b5"), new DateTime(2019, 10, 18, 16, 10, 24, 326, DateTimeKind.Local).AddTicks(5407), new DateTime(1980, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 10, 18, 16, 10, 24, 328, DateTimeKind.Local).AddTicks(6586), "Daniel", "Hoffman" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Discriminator", "LastUpdated", "Name", "Surname" },
                values: new object[] { new Guid("999369bf-6c17-4575-8087-7445d0f47ba0"), new DateTime(2019, 10, 18, 16, 10, 24, 328, DateTimeKind.Local).AddTicks(7167), new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 10, 18, 16, 10, 24, 328, DateTimeKind.Local).AddTicks(7177), "Albert", "Heisenower" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Discriminator", "LastUpdated", "Name", "Surname" },
                values: new object[] { new Guid("28dcee5f-0509-4e04-9162-ac8a3bd601ca"), new DateTime(2019, 10, 18, 16, 10, 24, 328, DateTimeKind.Local).AddTicks(7185), new DateTime(1960, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedCustomer", new DateTime(2019, 10, 18, 16, 10, 24, 328, DateTimeKind.Local).AddTicks(7188), "Stephen", "King" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreationDate", "CustomerId", "Date", "Discriminator", "LastUpdated" },
                values: new object[,]
                {
                    { new Guid("87d7c60e-8fe1-4a19-80e6-40dbca019485"), new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(3523), new Guid("971f3745-fc7b-465a-9984-7c72747480b5"), new DateTime(2019, 11, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(3051) },
                    { new Guid("982ea09b-0a22-4e98-80a1-d172ac89e38a"), new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(4004), new Guid("971f3745-fc7b-465a-9984-7c72747480b5"), new DateTime(2019, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(3994) },
                    { new Guid("0f5031e8-497e-45f5-9662-c4e0c91c2e41"), new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(4015), new Guid("999369bf-6c17-4575-8087-7445d0f47ba0"), new DateTime(2019, 10, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(4012) },
                    { new Guid("4df23fae-2a32-4c50-a697-45f8bcc7bf4d"), new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(4021), new Guid("28dcee5f-0509-4e04-9162-ac8a3bd601ca"), new DateTime(2019, 12, 25, 18, 15, 0, 0, DateTimeKind.Unspecified), "SeedAppointment", new DateTime(2019, 10, 18, 16, 10, 24, 331, DateTimeKind.Local).AddTicks(4018) }
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
