using Concessionaria.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosIniciaisMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ConcessionariaDbContext();
            context.Marca.AddRange(ObterCargaInicialMarca());
            context.SaveChanges();
        }

        private IList<Marca> ObterCargaInicialMarca()
        {
            return new List<Marca>()
            {
                new Marca() { Descricao = "Audi"},
                new Marca() { Descricao = "Volkswagen"},
                new Marca() { Descricao = "Toyota"},
                new Marca() { Descricao = "Ford"},
                new Marca() { Descricao = "Chevrolet"},
                new Marca() { Descricao = "Nissan"},
                new Marca() { Descricao = "Fiat"},
                new Marca() { Descricao = "Bmw"},
                new Marca() { Descricao = "Kia"},
                new Marca() { Descricao = "Byd"},
            };
        }
       
    }
}
