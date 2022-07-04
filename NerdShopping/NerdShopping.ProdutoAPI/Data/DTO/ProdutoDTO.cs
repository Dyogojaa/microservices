using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NerdShopping.ProdutoAPI.Data.DTO;

public class ProdutoDTO
{
    public long Id { get; set; }        
    public string? Nome { get; set; }        
    public decimal Preco { get; set; }        
    public string? Descricao { get; set; }        
    public string? Categoria { get; set; }        
    public string? ImagemUrl { get; set; }
}
