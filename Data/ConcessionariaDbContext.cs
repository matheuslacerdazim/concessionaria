using Concessionaria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Concessionaria.Data;

public class ConcessionariaDbContext : IdentityDbContext
{
    public DbSet<Carro> Carro { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<Opcional> Opcional { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var stringConn = config.GetConnectionString("StringConn");

        optionsBuilder.UseSqlServer(stringConn);
    }
}
