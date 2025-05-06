using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Sokhna.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofEmployed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "Equipmentss",
                columns: table => new
                {
                    Eq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourPrice = table.Column<float>(type: "real", nullable: false),
                    HourCount = table.Column<float>(type: "real", nullable: false),
                    DateOfAdding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipmentss", x => x.Eq_ID);
                    table.ForeignKey(
                        name: "FK_Equipmentss_Userss_SSN",
                        column: x => x.SSN,
                        principalTable: "Userss",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expensess",
                columns: table => new
                {
                    Exp_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAdding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensess", x => x.Exp_ID);
                    table.ForeignKey(
                        name: "FK_Expensess_Userss_SSN",
                        column: x => x.SSN,
                        principalTable: "Userss",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacts",
                columns: table => new
                {
                    Pact_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAdding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacts", x => x.Pact_ID);
                    table.ForeignKey(
                        name: "FK_Pacts_Userss_SSN",
                        column: x => x.SSN,
                        principalTable: "Userss",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies_Incomes",
                columns: table => new
                {
                    SI_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    DateOfAdding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies_Incomes", x => x.SI_ID);
                    table.ForeignKey(
                        name: "FK_Supplies_Incomes_Userss_SSN",
                        column: x => x.SSN,
                        principalTable: "Userss",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies_Outcomes",
                columns: table => new
                {
                    SO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CountPrice = table.Column<float>(type: "real", nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies_Outcomes", x => x.SO_ID);
                    table.ForeignKey(
                        name: "FK_Supplies_Outcomes_Userss_SSN",
                        column: x => x.SSN,
                        principalTable: "Userss",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipmentss_SSN",
                table: "Equipmentss",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_SSN",
                table: "Expensess",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Pacts_SSN",
                table: "Pacts",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_Incomes_SSN",
                table: "Supplies_Incomes",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_Outcomes_SSN",
                table: "Supplies_Outcomes",
                column: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipmentss");

            migrationBuilder.DropTable(
                name: "Expensess");

            migrationBuilder.DropTable(
                name: "Pacts");

            migrationBuilder.DropTable(
                name: "Supplies_Incomes");

            migrationBuilder.DropTable(
                name: "Supplies_Outcomes");

            migrationBuilder.DropTable(
                name: "Userss");
        }
    }
}
