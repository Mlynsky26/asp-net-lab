using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1fa2774a-54b8-46b2-8a05-b871276d3c48", "636b200e-694f-4693-a4d4-c2e83644d8a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa2774a-54b8-46b2-8a05-b871276d3c48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "636b200e-694f-4693-a4d4-c2e83644d8a0");

            migrationBuilder.DropColumn(
                name: "owner",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "engine_type",
                table: "cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "cars",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11df366d-1b50-4f8e-92ca-b5193de2fa4f", "11df366d-1b50-4f8e-92ca-b5193de2fa4f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e2e6b74-d422-4719-8eb3-a4fe37937d62", 0, "07ffd1b1-bf27-4f80-b10d-a94a61fa9b6f", "adam@gmail.com", true, false, null, "ADAM@GMAIL.COM", "ADAM", "AQAAAAEAACcQAAAAEMLfRuCTzxUEDKJrBGskXgxzr+KYtUZXcveEg5Ju9GP8ylAXwjXUAe9jjX68oAKH6g==", null, false, "4e0079b0-2f07-49a6-a6dd-3649cc832302", false, "adam" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name", "Phone", "Surname", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Darek", "123456789", "Kowalski", "Krakow", "31-200", "Filpa" },
                    { 2, "Mariusz", "987654321", "Nowak", "Warszawa", "54-120", "Fiolkowa" }
                });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "engine_type", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "engine_type", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11df366d-1b50-4f8e-92ca-b5193de2fa4f", "1e2e6b74-d422-4719-8eb3-a4fe37937d62" });

            migrationBuilder.CreateIndex(
                name: "IX_cars_OwnerId",
                table: "cars",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_Owners_OwnerId",
                table: "cars",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_Owners_OwnerId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_cars_OwnerId",
                table: "cars");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11df366d-1b50-4f8e-92ca-b5193de2fa4f", "1e2e6b74-d422-4719-8eb3-a4fe37937d62" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11df366d-1b50-4f8e-92ca-b5193de2fa4f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e2e6b74-d422-4719-8eb3-a4fe37937d62");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "cars");

            migrationBuilder.AlterColumn<string>(
                name: "engine_type",
                table: "cars",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fa2774a-54b8-46b2-8a05-b871276d3c48", "1fa2774a-54b8-46b2-8a05-b871276d3c48", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "636b200e-694f-4693-a4d4-c2e83644d8a0", 0, "88bd8252-9455-4bca-83b5-8c24a910886a", "adam@gmail.com", true, false, null, "ADAM@GMAIL.COM", "ADAM", "AQAAAAEAACcQAAAAEPdH/fzBbitEmkCpFDLqGqXV9MNAhxSZn7y/13m27O+yUqfjGBePgM3Nmd1z68I8aA==", null, false, "5dc5e439-c02e-46bd-9721-9dd46d6914f4", false, "adam" });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "engine_type", "owner" },
                values: new object[] { "Benzyna", "Jarek" });

            migrationBuilder.UpdateData(
                table: "cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "engine_type", "owner" },
                values: new object[] { "Diesel", "Darek" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1fa2774a-54b8-46b2-8a05-b871276d3c48", "636b200e-694f-4693-a4d4-c2e83644d8a0" });
        }
    }
}
