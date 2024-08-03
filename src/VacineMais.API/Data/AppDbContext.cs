using Microsoft.EntityFrameworkCore;
using VacineMais.API.Models;

namespace VacineMais.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Imunobiologico> Imunobiologico { get; set; }

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\VacineMaisDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>()
                .HasMany(f => f.Membros)
                .WithOne(m => m.Familia)
                .HasForeignKey(m => m.FamiliaId);

            modelBuilder.Entity<Membro>()
                .HasOne(m => m.Familia)
                .WithMany(f => f.Membros)
                .HasForeignKey(m => m.FamiliaId);

            modelBuilder.Entity<Imunobiologico>()
                .HasIndex(i => i.Codigo);

            modelBuilder.Entity<Imunobiologico>()
                .HasData(DbSeed.SeedImunobiologicos());
        }
    }
}
