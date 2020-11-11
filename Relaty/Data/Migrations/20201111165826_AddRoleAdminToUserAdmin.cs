using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class AddRoleAdminToUserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) " +
                "VALUES (N'6286ff9b-681b-4160-9772-701a2d8e957a', N'91ad31f9-c5ec-41d9-bc32-82131e43b2ea')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
