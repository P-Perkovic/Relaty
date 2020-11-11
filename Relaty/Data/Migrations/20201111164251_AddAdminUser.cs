using Microsoft.EntityFrameworkCore.Migrations;

namespace Relaty.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash]," +
                " [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) " +
                "VALUES (N'6286ff9b-681b-4160-9772-701a2d8e957a', N'admin@relaty.com', N'ADMIN@RELATY.COM', N'admin@relaty.com', N'ADMIN@RELATY.COM', 1, " +
                "N'AQAAAAEAACcQAAAAEJLMoiqlt4dOHp3aiF/ks9uNcAaUC+aKWDWg7tuRfNUGAoGs5uPPd+Xb5rjScq1jAw==', N'S46C7PFLOZHBE7LP2M2RQR6FYMLCFARZ', " +
                "N'445ff079-82dd-45f0-9216-9a933725d3b8', NULL, 0, 0, NULL, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
