using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCardapioFinal.Models
{
    [Table("Prato")]
    public class Prato
    {
        [Column("PratoId")]
        [Display(Name = "Código do Prato")]
        public int PratoId { get; set; }

        [Column("DescricaoPrato")]
        [Display(Name = "Descricao do Prato")]
        public string DescricaoPrato { get; set; } = string.Empty;

        [Column("DescricaoBebida")]
        [Display(Name = "Descricao da Bebida")]
        public string DescricaoBebida { get; set; } = string.Empty;

        [Column("DescricaoVegetariana")]
        [Display(Name = "Descricao Vegetariana")]
        public string DescricaoVegetariana { get; set; } = string.Empty;
    }
}
