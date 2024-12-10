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

        // Adicionando DbSet para Comentario
        public DbSet<Comentario> Comentarios { get; set; }

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

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Refeicao)  // Relacionamento com Refeição
                .WithMany(r => r.Comentarios)  // Refeição pode ter muitos Comentarios
                .HasForeignKey(c => c.RefeicaoId)  // A chave estrangeira é RefeicaoId
                .OnDelete(DeleteBehavior.Cascade);  // Comportamento de exclusão

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Nutricionista)  // Relacionamento com Nutricionista
                .WithMany()  // A relação reversa não precisa ser explícita
                .HasForeignKey(c => c.NutricionistaId)  // Chave estrangeira NutricionistaId
                .OnDelete(DeleteBehavior.Restrict);  // Evitar exclusão em cascata do nutricionista


            modelBuilder.Entity<RelacionamentoNutricionistaCliente>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Questionario> Questionarios { get; set; }
    }
}
