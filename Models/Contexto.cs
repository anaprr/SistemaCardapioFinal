using Microsoft.EntityFrameworkCore;
using System.IO;

namespace SistemaCardapioFinal.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Base> Base { get; set; }
        public DbSet<Acompanhamento> Acompanhamento { get; set; }
        public DbSet<Salada> Salada { get; set; }
        public DbSet<Sobremesa> Sobremesa { get; set; }
        public DbSet<Bebida> Bebida { get; set; }

        public DbSet<Desperdicio> Desperdicio { get; set; }
            
        public DbSet<Cardapio> Cardapio { get; set; }
        }
    }

