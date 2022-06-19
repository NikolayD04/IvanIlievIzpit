using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEOID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Companies_People_CEOID",
                        column: x => x.CEOID,
                        principalTable: "People",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CEOID",
                table: "Companies",
                column: "CEOID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PersonID",
                table: "Games",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
