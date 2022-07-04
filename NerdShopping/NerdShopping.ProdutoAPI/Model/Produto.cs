using NerdShopping.ProdutoAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NerdShopping.ProdutoAPI.Model;

[Table("produto")]
public class Produto :BaseEntity
{
    [Column("nome")]
    [Required]
    [StringLength(150)]
    public string? Nome { get; set; }


    [Column("preco")]
    [Required]
    [Range(1,100000)]
    public decimal Preco { get; set; }

    [Column("descricao")]    
    [StringLength(500)]
    public string? Descricao { get; set; }

    [Column("categoria")]
    [Required]
    public string? Categoria { get; set; }

    [Column("imagem_url")]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }



}
