using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concessionaria.Models;

public class Carro
{
    public int Id { get; set; }

    [Display(Name = "Modelo")]
    [Required(ErrorMessage = "Campo 'Modelo' obrigatório")]
    public string Modelo { get; set; }

    [Display(Name = "Preço")]
    [Required(ErrorMessage = "Campo 'Preço' obrigatório")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [Display(Name = "Ano do veículo")]
    [Required(ErrorMessage = "Campo 'Ano' obrigatório")]
    [DisplayFormat(DataFormatString = "{0: yyyy}")]        
    public DateTime Ano { get; set; }

    [Display(Name = "Disponível")]
    public bool Disponivel { get; set; }
    public string DisponivelFormatado => Disponivel ? "Sim" : "Não";

    [Required(ErrorMessage = "Campo 'Url da Imagem' obrigatório")]
    public string ImageUri {  get; set; }

    [Display(Name = "Marca")]
    public int? MarcaId { get; set; }   

    public ICollection<Opcional>? Opcionais { get; set; }
    

}
