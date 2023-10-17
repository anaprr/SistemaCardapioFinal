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

            public DbSet<Desperdicio> Desperdicio { get; set; }

            public DbSet<Prato> Prato { get; set; }

            public DbSet<Cardapio> Cardapio { get; set; }
        }
    }

