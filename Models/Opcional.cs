namespace Concessionaria.Models;

public class Opcional
{
    public int OpcionalId { get; set; }
    public string Descricao { get; set; }
    public ICollection<Carro>? Carros { get; set; }

}
