using Microsoft.EntityFrameworkCore;

namespace verdeconecta.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Refeicao> Refeicoes { get; set; }
        public DbSet<Meta> Metas { get; set; }

        public DbSet<DicasNutricionais> DicasNutricionais { get; set; }

        public DbSet<RelacionamentoNutricionistaCliente> RelacionamentoNutricionistaCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RelacionamentoNutricionistaCliente
            modelBuilder.Entity<RelacionamentoNutricionistaCliente>()
                .HasKey(r => new { r.IdNutricionista, r.IdCliente });

            modelBuilder.Entity<RelacionamentoNutricionistaCliente>()
                .HasOne(r => r.Nutricionista)
                .WithMany()
                .HasForeignKey(r => r.IdNutricionista)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RelacionamentoNutricionistaCliente>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
