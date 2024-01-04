using Concessionaria.Models;

namespace Concessionaria.Services
{
    public interface ICarService
    {
        public IList<Carro> ObterTodosOsCarros();
        public Carro ObterUmCarro(int id);
        public void IncluirCarro(Carro Carro);
        public void Alterar(Carro Carro);
        public void Excluir(int id);
        IList<Marca> ObterTodasMarcas();
        Marca ObterMarca(int id);
        IList<Opcional> ObterTodosOpcionais();

    }
}
