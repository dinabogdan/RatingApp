using Microsoft.EntityFrameworkCore;
using RatingApp.Infrastructure.Database.Model;

#nullable disable

namespace RatingApp.Infrastructure.Database
{
    public partial class RatingContext : DbContext
    {
        public RatingContext()
        {
        }

        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("product_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.HasSequence("rating_id_seq").HasMax(100000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
