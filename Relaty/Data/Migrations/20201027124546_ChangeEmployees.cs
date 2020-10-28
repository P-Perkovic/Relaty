using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class ChangeEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
