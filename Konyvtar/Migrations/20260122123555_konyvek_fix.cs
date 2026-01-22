using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konyvtar.Migrations
{
    /// <inheritdoc />
    public partial class konyvek_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mufaj",
                table: "Konyvek");

            migrationBuilder.DropColumn(
                name: "Szerzo",
                table: "Konyvek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mufaj",
                table: "Konyvek",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Szerzo",
                table: "Konyvek",
                type: "longtext",
                nullable: false);
        }
    }
}
