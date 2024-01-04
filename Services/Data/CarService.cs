using Concessionaria.Data;
using Concessionaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Services.Data;

public class CarService : ICarService
{
    private ConcessionariaDbContext _context;

    public CarService(ConcessionariaDbContext context)
    {
        _context = context;
    }

    public void Alterar(Carro Carro)
    {
        var carroEncontrado = ObterUmCarro(Carro.Id);
        carroEncontrado.Preco = Carro.Preco;
        carroEncontrado.Modelo = Carro.Modelo;
        carroEncontrado.Disponivel = Carro.Disponivel;
        carroEncontrado.Ano = Carro.Ano;
        carroEncontrado.ImageUri = Carro.ImageUri;
        carroEncontrado.MarcaId = Carro.MarcaId;
        carroEncontrado.Opcionais = Carro.Opcionais;
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var carroEncontrado = ObterUmCarro(id);
        _context.Carro.Remove(carroEncontrado);
        _context.SaveChanges();
    }

    public void IncluirCarro(Carro Carro)
    {
        _context.Carro.Add(Carro);
        _context.SaveChanges();
    }

    public IList<Carro> ObterTodosOsCarros()
    {
       return _context.Carro.ToList();
    }

    public Carro ObterUmCarro(int id)
    {
        return _context.Carro
                        .Include(item => item.Opcionais)
                        .SingleOrDefault(item => item.Id == id);
    }

    public IList<Marca> ObterTodasMarcas()
        => _context.Marca.ToList();

    public Marca ObterMarca(int id)
     => _context.Marca.SingleOrDefault(item => item.MarcaId == id);

    public IList<Opcional> ObterTodosOpcionais()    
        => _context.Opcional.ToList();
    

}
