using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCardapioFinal.Models
{
    [Table("Salada")]
    public class Salada
    {
        [Column("SaladaId")]
        [Display(Name = "Código da Salada")]
        public int Id { get; set; }

        [Column("DescricaoSalada")]
        [Display(Name = "Descricao da Salada")]
        public string DescricaoSalada { get; set; } = string.Empty;
    }
}
