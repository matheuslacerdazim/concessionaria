using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoCarroOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroOpcional",
                columns: table => new
                {
                    CarrosId = table.Column<int>(type: "int", nullable: false),
                    OpcionaisOpcionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroOpcional", x => new { x.CarrosId, x.OpcionaisOpcionalId });
                    table.ForeignKey(
                        name: "FK_CarroOpcional_Carro_CarrosId",
                        column: x => x.CarrosId,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroOpcional_Opcional_OpcionaisOpcionalId",
                        column: x => x.OpcionaisOpcionalId,
                        principalTable: "Opcional",
                        principalColumn: "OpcionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroOpcional_OpcionaisOpcionalId",
                table: "CarroOpcional",
                column: "OpcionaisOpcionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroOpcional");
        }
    }
}
