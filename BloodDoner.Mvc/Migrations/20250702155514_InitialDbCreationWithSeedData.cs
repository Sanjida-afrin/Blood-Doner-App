using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDoner.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreationWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodDoners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDonationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDoners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodDonerId = table.Column<int>(type: "int", nullable: false),
                    BloodDonerEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_BloodDoners_BloodDonerEntityId",
                        column: x => x.BloodDonerEntityId,
                        principalTable: "BloodDoners",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BloodDoners",
                columns: new[] { "Id", "Address", "BloodGroup", "ContactNumber", "DateofBirth", "Email", "FullName", "LastDonationDate", "ProfilePicture", "Weight" },
                values: new object[,]
                {
                    { 1, "Chittagong", 2, "957579758975", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "saima@gmail.com", "Sanjida Afrin", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "profiles/Screenshot (178).png", 60f },
                    { 2, "Dhaka", 0, "123747428778", new DateTime(2005, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "saima@gmail.com", "Saima khan", new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "profiles/Screenshot (178).png", 90f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodDonerEntityId",
                table: "Donations",
                column: "BloodDonerEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "BloodDoners");
        }
    }
}
