using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Sokhna.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplyAdder",
                table: "Supplies_Incomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfConfirmation",
                table: "Pacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PactAdder",
                table: "Pacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplyAdder",
                table: "Supplies_Incomes");

            migrationBuilder.DropColumn(
                name: "DateOfConfirmation",
                table: "Pacts");

            migrationBuilder.DropColumn(
                name: "PactAdder",
                table: "Pacts");
        }
    }
}
