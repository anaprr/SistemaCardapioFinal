using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCardapioFinal.Models
{
    [Table("Acompanhamento")]
    public class Acompanhamento
    {
        [Column("AcompanhamentoId")]
        [Display(Name = "Código do Acompanhamento")]
        public int Id { get; set; }

        [Column("DescricaoAcompanhamento")]
        [Display(Name = "Descricao do Acompanhamento do Prato")]
        public string DescricaoAcompanhamento { get; set; } = string.Empty;
    }
}
