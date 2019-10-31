using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedRepositoryDesignPattern.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    EMail = table.Column<string>(maxLength: 150, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "EMail", "Name", "Password", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 1, 13, 1, 53, 795, DateTimeKind.Utc).AddTicks(3050), "e.dedeoglu@gmail.com", "Erçin", "1q2w3e4r", "Dedeoğlu", "Phantasm" },
                    { 2, new DateTime(2019, 10, 1, 13, 1, 53, 795, DateTimeKind.Utc).AddTicks(7400), "ata.dedeoglu@unknown.com", "Ata", "123456", "Dedeoğlu", "Atiş" },
                    { 3, new DateTime(2019, 10, 1, 13, 1, 53, 795, DateTimeKind.Utc).AddTicks(7535), "dedeco@yahoo.com", "İmdat Ercan", "1234", "Dedeoğlu", "Eco" },
                    { 4, new DateTime(2019, 10, 1, 13, 1, 53, 795, DateTimeKind.Utc).AddTicks(7547), "yusuf.dedeoglu@unknown.com", "Yusuf", "654321", "Dedeoğlu", "Dedeler" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
