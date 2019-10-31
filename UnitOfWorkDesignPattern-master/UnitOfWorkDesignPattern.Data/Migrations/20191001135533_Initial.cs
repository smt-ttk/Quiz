using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitOfWorkDesignPattern.Data.Migrations
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
                    { 1, new DateTime(2019, 10, 1, 13, 55, 33, 673, DateTimeKind.Utc).AddTicks(3937), "e.dedeoglu@gmail.com", "Erçin", "1q2w3e4r", "Dedeoğlu", "Phantasm" },
                    { 2, new DateTime(2019, 10, 1, 13, 55, 33, 673, DateTimeKind.Utc).AddTicks(7989), "ata.dedeoglu@unknown.com", "Ata", "123456", "Dedeoğlu", "Atiş" },
                    { 3, new DateTime(2019, 10, 1, 13, 55, 33, 673, DateTimeKind.Utc).AddTicks(8139), "dedeco@yahoo.com", "İmdat Ercan", "1234", "Dedeoğlu", "Eco" },
                    { 4, new DateTime(2019, 10, 1, 13, 55, 33, 673, DateTimeKind.Utc).AddTicks(8152), "yusuf.dedeoglu@unknown.com", "Yusuf", "654321", "Dedeoğlu", "Dedeler" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
