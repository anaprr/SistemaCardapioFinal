using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCardapioFinal.Models
{
    [Table("Base")]
    public class Base
    {
        [Column("BaseId")]
        [Display(Name = "Código da Base do Prato")]
        public int Id { get; set; }

        [Column("DescricaoBase")]
        [Display(Name = "Descricao da Base do Prato")]
        public string DescricaoBase { get; set; } = string.Empty;
    }
}
