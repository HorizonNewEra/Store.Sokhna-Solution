using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Sokhna.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class M7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserssDatas",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserssDatas", x => x.SSN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserssDatas");
        }
    }
}
