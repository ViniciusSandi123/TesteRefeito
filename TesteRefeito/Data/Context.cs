using Microsoft.EntityFrameworkCore;
using TesteRefeito.Models;

namespace TesteRefeito.Data
{
    public class Context : DbContext
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Streaming> Streamings { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
