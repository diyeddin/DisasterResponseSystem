using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponseSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestingModelsToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleInNeed",
                columns: table => new
                {
                    PersonInNeedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleInNeed", x => x.PersonInNeedID);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedAmount = table.Column<int>(type: "int", nullable: false),
                    AllocatedAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonInNeedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Requests_PeopleInNeed_PersonInNeedID",
                        column: x => x.PersonInNeedID,
                        principalTable: "PeopleInNeed",
                        principalColumn: "PersonInNeedID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PersonInNeedID",
                table: "Requests",
                column: "PersonInNeedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "PeopleInNeed");
        }
    }
}
