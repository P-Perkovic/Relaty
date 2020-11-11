using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) " +
                "VALUES ('91ad31f9-c5ec-41d9-bc32-82131e43b2ea', 'Admin', 'ADMIN', '66c83dcf-9cf7-4b90-8fd9-83f62fb553c9')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
