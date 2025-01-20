using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeveloperStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StartDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 150, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: false),
                    Latitude = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: false),
                    Longitude = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_Id",
                        column: x => x.Id,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
