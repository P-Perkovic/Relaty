using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class UpdateProjectsEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Employees_EmployeeId",
                table: "ProjectEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Projects_ProjectId",
                table: "ProjectEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployee",
                table: "ProjectEmployee");

            migrationBuilder.RenameTable(
                name: "ProjectEmployee",
                newName: "ProjectsEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectsEmployees",
                newName: "IX_ProjectsEmployees_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsEmployees",
                table: "ProjectsEmployees",
                columns: new[] { "ProjectId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeeId",
                table: "ProjectsEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectId",
                table: "ProjectsEmployees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeeId",
                table: "ProjectsEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectId",
                table: "ProjectsEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsEmployees",
                table: "ProjectsEmployees");

            migrationBuilder.RenameTable(
                name: "ProjectsEmployees",
                newName: "ProjectEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsEmployees_EmployeeId",
                table: "ProjectEmployee",
                newName: "IX_ProjectEmployee_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployee",
                table: "ProjectEmployee",
                columns: new[] { "ProjectId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Employees_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Projects_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
