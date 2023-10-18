using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCardapioFinal.Models
{
    [Table("Cardapio")]
    public class Cardapio
    {
        [Column("CardapioId")]
        [Display(Name = "Código do Cardapio")]
        public int CardapioId { get; set; }

        [Column("CardapioNome")]
        [Display(Name = "Dia da Semana")]
        public string CardapioNome { get; set; } = string.Empty;

        [ForeignKey("PratoId")]
        public int PratoId { get; set; }

        public Prato? Prato { get; set; }

    }
}
