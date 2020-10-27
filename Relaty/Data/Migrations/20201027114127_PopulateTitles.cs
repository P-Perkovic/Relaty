using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class PopulateTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Analyst')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Architect')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Project Manager')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Front-end Developer')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Back-end Developer')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Full-stack Developer')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('UI/UX Developer')");
            migrationBuilder.Sql("INSERT INTO Titles (Name) VALUES ('Database Developer')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
