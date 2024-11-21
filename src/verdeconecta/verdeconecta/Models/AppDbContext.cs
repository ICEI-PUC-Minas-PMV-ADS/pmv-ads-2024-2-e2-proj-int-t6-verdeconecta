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

    }
}
