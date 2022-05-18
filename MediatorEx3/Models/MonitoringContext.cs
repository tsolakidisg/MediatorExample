using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MediatorEx3.Models
{
    public partial class MonitoringContext : DbContext
    {
        public MonitoringContext()
        {
        }

        public MonitoringContext(DbContextOptions<MonitoringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetailLog> DetailLogs { get; set; }
        public virtual DbSet<HeadLog> HeadLogs { get; set; }
        public virtual DbSet<Step> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Monitoring;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DetailLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DETAIL_Log");

                entity.Property(e => e.EndSystem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("END_SYSTEM");

                entity.Property(e => e.Exception)
                    .HasMaxLength(255)
                    .HasColumnName("EXCEPTION");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("GUID");

                entity.Property(e => e.LevelType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("LEVEL_TYPE");

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ORDER_TYPE");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("PAYLOAD");

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("SERVICE");

                entity.Property(e => e.StackTrace).HasColumnName("STACK_TRACE");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("STATE");

                entity.Property(e => e.Tmstamp)
                    .HasColumnType("datetime")
                    .HasColumnName("TMSTAMP");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("UUID");

                entity.HasOne(d => d.Gu)
                    .WithMany()
                    .HasForeignKey(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETAIL_Log__GUID__6477ECF3");
            });

            modelBuilder.Entity<HeadLog>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK__tmp_ms_x__15B69B8E239F0D95");

                entity.ToTable("HEAD_Log");

                entity.Property(e => e.Guid)
                    .HasMaxLength(255)
                    .HasColumnName("GUID");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ORDER_STATUS");

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ORDER_TYPE");

                entity.Property(e => e.Tmstamp)
                    .HasColumnType("datetime")
                    .HasColumnName("TMSTAMP");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("STEPS");

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_TYPE");

                entity.Property(e => e.StepDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STEP_DESCRIPTION");

                entity.Property(e => e.StepId).HasColumnName("STEP_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
