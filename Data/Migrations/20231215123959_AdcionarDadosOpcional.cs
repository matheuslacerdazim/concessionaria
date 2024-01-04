using Concessionaria.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ConcessionariaDbContext();
            context.Opcional.AddRange(ObterCargaInicialOpcional());
            context.SaveChanges();
        }

        private IList<Opcional> ObterCargaInicialOpcional()
        {
            return new List<Opcional>()
            {
                new Opcional() { Descricao = "Bancos em couro"},
                new Opcional() { Descricao = "Ar condicionado"},
                new Opcional() { Descricao = "Teto solar"},
                new Opcional() { Descricao = "Travas elétricas"},
                new Opcional() { Descricao = "Direção hidráulica"},
                new Opcional() { Descricao = "Rodas em liga leve"},
                new Opcional() { Descricao = "Controle automático de velocidade"},
                new Opcional() { Descricao = "Sensor de estacionamento"}



            };
        }

    }
}
