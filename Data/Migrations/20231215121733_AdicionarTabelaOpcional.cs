using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opcional",
                columns: table => new
                {
                    OpcionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcional", x => x.OpcionalId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opcional");
        }
    }
}
