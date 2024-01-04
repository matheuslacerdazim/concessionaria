namespace Concessionaria.Models;

public class Marca
{
    public int MarcaId { get; set; }
    public string Descricao { get; set; }
    public ICollection<Carro>? Carros {get; set;}


}
