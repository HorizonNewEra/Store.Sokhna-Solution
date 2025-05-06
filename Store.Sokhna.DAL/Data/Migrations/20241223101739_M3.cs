using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Sokhna.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Importers",
                columns: table => new
                {
                    Imp_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importers", x => x.Imp_ID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    W_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.W_ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkersSalaries",
                columns: table => new
                {
                    WS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourPrice = table.Column<float>(type: "real", nullable: false),
                    HourCount = table.Column<float>(type: "real", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkersSalaries", x => x.WS_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Importers");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "WorkersSalaries");
        }
    }
}
