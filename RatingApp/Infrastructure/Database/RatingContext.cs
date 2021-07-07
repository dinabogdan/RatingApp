using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RatingApp.Infrastructure.Database.Model
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

        public virtual DbSet<OutboxedEvent> OutboxedEvents { get; set; }
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

            modelBuilder.Entity<OutboxedEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("outbox");

                entity.Property(e => e.AggregateId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aggregate_id");

                entity.Property(e => e.AggregateType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aggregate_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Metadata)
                    .HasMaxLength(255)
                    .HasColumnName("metadata");

                entity.Property(e => e.OccurredAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("occurred_at");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload");

                entity.Property(e => e.PayloadContentType)
                    .HasMaxLength(255)
                    .HasColumnName("payload_content_type");

                entity.Property(e => e.PayloadSchema)
                    .HasMaxLength(2500)
                    .HasColumnName("payload_schema");

                entity.Property(e => e.PayloadSchemaId)
                    .HasMaxLength(255)
                    .HasColumnName("payload_schema_id");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasDefaultValueSql("nextval('outbox_seq'::regclass)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("version");
            });

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

            modelBuilder.HasSequence("outbox_seq").HasMax(9999999);

            modelBuilder.HasSequence("rating_id_seq").HasMax(100000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
