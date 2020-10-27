using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class PopulateStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('New')");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('In Progress')");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('Completed')");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('On Hold')");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('Canceled')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
