using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Sokhna.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Importer",
                table: "Supplies_Outcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Importer",
                table: "Supplies_Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Pacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Importer",
                table: "Equipmentss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importer",
                table: "Supplies_Outcomes");

            migrationBuilder.DropColumn(
                name: "Importer",
                table: "Supplies_Incomes");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Pacts");

            migrationBuilder.DropColumn(
                name: "Importer",
                table: "Equipmentss");
        }
    }
}
