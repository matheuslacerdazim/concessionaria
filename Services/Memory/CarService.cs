namespace Concessionaria.Services.Memory;

using Models;
using System.ComponentModel.DataAnnotations;

public class CarService : ICarService
{
    public CarService() =>
        GerarListaInicialDeCarros();

    private IList<Carro> _carros;

    public void GerarListaInicialDeCarros()
    {
        _carros = new List<Carro>
        {
            new Carro
            {
                Id = 1,
                Modelo = "Camaro",
                Preco = 10,
                Ano = new DateTime(1997,4,12),
                Disponivel = true,
                ImageUri = "/img/camaro.jpg"
            },

            new Carro
            {
                Id = 2,
                Modelo = "M2",
                Preco = 10,
                Ano = new DateTime(2020,6,4),
                Disponivel = true,
                ImageUri = "/img/m_2.jpg"
            },

            new Carro
            {
                Id = 3,
                Modelo = "Skyline",
                Preco = 10,
                Ano = new DateTime(1999,6,17),
                Disponivel = true,
                ImageUri = "/img/skyline.jpg"
            },

            new Carro
            {
                Id = 4,
                Modelo = "Supra",
                Preco = 10,
                Ano = new DateTime(2023,5,11),
                Disponivel = true,
                ImageUri = "/img/supra.jpg"
            }
        };
    }

    public IList<Carro> ObterTodosOsCarros()
    {
        return _carros;
    }

    public Carro ObterUmCarro(int id)
    {
        return ObterTodosOsCarros().SingleOrDefault(item => item.Id == id);
    }

    public void IncluirCarro(Carro carro)
    {
        var proximoId = _carros.Max(item => item.Id) + 1;
        carro.Id = proximoId;
        _carros.Add(carro);
    }

    public void Alterar(Carro carro)
    {
        var carroEncontrado = _carros.SingleOrDefault(item => item.Id == carro.Id);
        carroEncontrado.Modelo = carro.Modelo;
        carroEncontrado.Preco = carro.Preco;
        carroEncontrado.Disponivel = carro.Disponivel;
        carroEncontrado.Ano = carro.Ano;
        carroEncontrado.ImageUri = carro.ImageUri;

    }

    public void Excluir(int id)
    {
        var carroEncontrado = ObterUmCarro(id);
        _carros.Remove(carroEncontrado);
    }
    
    public IList<Marca> ObterTodasMarcas()
    {
        throw new NotImplementedException();
    }

    public Marca ObterMarca(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Opcional> ObterTodosOpcionais()
    {
        throw new NotImplementedException();
    }
}

