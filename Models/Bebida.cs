using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCardapioFinal.Models
{
    [Table("Bebida")]
    public class Bebida
    {
        [Column("BebidaId")]
        [Display(Name = "Código da Bebida")]
        public int Id { get; set; }

        [Column("DescricaoBebida")]
        [Display(Name = "Descricao da Bebida")]
        public string DescricaoBebida { get; set; } = string.Empty;
    }
}
