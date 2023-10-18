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

        [ForeignKey("BaseId")]
        public int BaseId { get; set; }
        public Base? Base { get; set; }

        [ForeignKey("AcompanhamentoId")]
        public int AcompanhamentoId { get; set; }

        public Acompanhamento? Acompanhamento { get; set; }

        [ForeignKey("SaladaId")]
        public int SaladaId { get; set; }

        public Salada? Salada { get; set; }

        [ForeignKey("BebidaId")]
        public int BebidaId { get; set; }

        public Bebida? Bebida { get; set; }

        [ForeignKey("SobremesaId")]
        public int SobremesaId { get; set; }

        public Sobremesa? Sobremesa { get; set; }

    }
}
