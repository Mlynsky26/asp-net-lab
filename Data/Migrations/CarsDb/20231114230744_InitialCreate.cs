using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations.CarsDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    maker = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    volume = table.Column<int>(type: "INTEGER", nullable: false),
                    power = table.Column<int>(type: "INTEGER", nullable: false),
                    engine_type = table.Column<string>(type: "TEXT", nullable: false),
                    registration = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    owner = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "engine_type", "maker", "name", "owner", "power", "registration", "volume" },
                values: new object[,]
                {
                    { 1, "Benzyna", "Seat", "Ibiza", "Jarek", 130, "KRA123AB", 1200 },
                    { 2, "Diesel", "Opel", "Astra", "Darek", 180, "WW123AB", 1800 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}
