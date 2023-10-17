using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCardapioFinal.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Column("Id")]
        [Display(Name = "Código do Aluno")]
        public int Id { get; set; }

        [Column("AlunoNome")]
        [Display(Name = "Nome do Aluno")]
        public string AlunoNome { get; set; } = string.Empty;
    }
}
