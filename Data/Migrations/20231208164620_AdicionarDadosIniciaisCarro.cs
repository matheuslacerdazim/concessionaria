using Concessionaria.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosIniciaisCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ConcessionariaDbContext();
            context.Carro.AddRange(ObterCargaInicialCarro());
            context.SaveChanges();
        }

        private IList<Carro> ObterCargaInicialCarro()
        {
            return new List<Carro>
            {
                new Carro
                {                    
                    Modelo = "Camaro",
                    Preco = 10,
                    Ano = new DateTime(1997, 4, 12),
                    Disponivel = true,
                    ImageUri = "/img/camaro.jpg"
                },

                new Carro
                {                    
                    Modelo = "M2",
                    Preco = 10,
                    Ano = new DateTime(2020, 6, 4),
                    Disponivel = true,
                    ImageUri = "/img/m_2.jpg"
                },

                new Carro
                {                    
                    Modelo = "Skyline",
                    Preco = 10,
                    Ano = new DateTime(1999, 6, 17),
                    Disponivel = true,
                    ImageUri = "/img/skyline.jpg"
                },

                new Carro
                {                    
                    Modelo = "Supra",
                    Preco = 10,
                    Ano = new DateTime(2023, 5, 11),
                    Disponivel = true,
                    ImageUri = "/img/supra.jpg"
                }
            };
        }


    }
}
