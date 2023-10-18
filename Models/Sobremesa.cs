using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCardapioFinal.Models
{
    [Table("Sobremesa")]
    public class Sobremesa
    {
        [Column("SobremesaId")]
        [Display(Name = "Código da Sobremesa")]
        public int Id { get; set; }

        [Column("DescricaoSobremesa")]
        [Display(Name = "Descricao da Sobremesa do Prato")]
        public string DescricaoSobremesa { get; set; } = string.Empty;
    }
}
