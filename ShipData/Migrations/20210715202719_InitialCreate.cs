using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Shipname = table.Column<string>(type: "TEXT", nullable: false),
                    Lengthmeters = table.Column<double>(name: "Length(meters)", type: "REAL", nullable: false),
                    Widthmeters = table.Column<double>(name: "Width(meters)", type: "REAL", nullable: false),
                    Shipcode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
