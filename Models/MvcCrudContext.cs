using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SISTEMADENOTAS.Models
{
    public partial class MvcCrudContext : DbContext
    {
        public MvcCrudContext()
        {
        }

        public MvcCrudContext(DbContextOptions<MvcCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NotasEst> NotasEsts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=CCBB-04\\CCBB04; database=MvcCrud; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotasEst>(entity =>
            {
                entity.HasKey(e => e.IdNotasE)
                    .HasName("PK__NotasEst__C2D0AC290435FF9B");

                entity.ToTable("NotasEst");

                entity.Property(e => e.Apellido).HasMaxLength(30);

                entity.Property(e => e.Iipn).HasColumnName("IIPN");

                entity.Property(e => e.Ipn).HasColumnName("IPN");

                entity.Property(e => e.Nf).HasColumnName("NF");

                entity.Property(e => e.Nombre).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
