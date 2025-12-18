using Microsoft.EntityFrameworkCore;

namespace Konyvtar.Models
{
    public class KonyvtarContext : DbContext
    {
        public KonyvtarContext(DbContextOptions<KonyvtarContext> options) : base(options)
        {
        }

        public DbSet<Diakok> Diakok { get; set; }
        public DbSet<Kolcsonzesek> Kolcsonzesek { get; set; }
        public DbSet<Konyvek> Konyvek { get; set; }
        public DbSet<Mufajok> Mufajok { get; set; }
        public DbSet<Olvasojegyek> Olvasojegyek { get; set; }
        public DbSet<Szerzok> Szerzok { get; set; }
        public DbSet<Szerzokonyvek> Szerzokonyvek { get; set; }
        public DbSet<Mufajkonyvek> Mufajkonyvek { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konyvek>()
            .HasMany(e => e.Mufajok)
            .WithMany(e => e.Konyvek)
            .UsingEntity<Mufajkonyvek>();

            modelBuilder.Entity<Konyvek>()
            .HasMany(e => e.Szerzok)
            .WithMany(e => e.Konyvek)
            .UsingEntity<Szerzokonyvek>();
        }
    }
}
