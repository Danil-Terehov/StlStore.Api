using Microsoft.EntityFrameworkCore;
using StlStore.Core.Domain;

namespace StlStore.Persistence.PostGre
{
    public class StlDbContext : DbContext
    {
        public StlDbContext(DbContextOptions<StlDbContext> options) : base(options) { }

        public DbSet<Figure> Figures { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<StlFile> StlFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure auto-generated IDs
            modelBuilder.Entity<Figure>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Author>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Collection>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StlFile>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            // Configure many-to-many relationship between Figure and Author
            modelBuilder.Entity<Figure>()
                .HasMany(f => f.Authors)
                .WithMany(a => a.Figures)
                .UsingEntity(j => j.ToTable("FigureAuthors"));

            // Configure many-to-many relationship between Collection and Author
            modelBuilder.Entity<Collection>()
                .HasMany(c => c.Authors)
                .WithMany(a => a.Collections)
                .UsingEntity(j => j.ToTable("CollectionAuthors"));

            // Configure one-to-many relationship between Figure and Collection
            modelBuilder.Entity<Figure>()
                .HasOne(f => f.Collection)
                .WithMany(c => c.Figures)
                .HasForeignKey(f => f.CollectionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure one-to-many relationship between StlFile and Figure
            modelBuilder.Entity<StlFile>()
                .HasOne(s => s.Figure)
                .WithMany(f => f.StlFiles)
                .HasForeignKey(s => s.FigureId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
