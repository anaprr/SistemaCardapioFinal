using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCardapioFinal.Models
{
    public class Desperdicio
    {
        [Column("DesperdicioId")]
        [Display(Name = "Código do Desperdicio")]
        public int DesperdicioId { get; set; }
        [Column("DataDesperdicio")]
        [Display(Name = "Data do Desperdicio")]
        public DateTime NomeVeiculo { get; set; }

        [Column("QtdAlimento")]
        [Display(Name = "Quantidade do Alimento")]
        public int QtdAlimento { get; set; }

        [Column("QtdDesperdicio")]
        [Display(Name = "Quantidade do Desperdicio")]
        public int QtdDesperdicio { get; set; }

        [Column("PorcentagemDesperdicio")]
        [Display(Name = "Porcentagem do Desperdicio")]
        public double PorcentagemDesperdicio { get; set; }
    }
}
