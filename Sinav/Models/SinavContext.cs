using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sinav.Models;

public partial class SinavContext : DbContext
{
    public SinavContext()
    {
    }

    public SinavContext(DbContextOptions<SinavContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boyut> Boyuts { get; set; }

    public virtual DbSet<Renk> Renks { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NI2QFQE;Database=sinav;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boyut>(entity =>
        {
            entity.ToTable("Boyut");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasMaxLength(50)
                .HasColumnName("adi");
        });

        modelBuilder.Entity<Renk>(entity =>
        {
            entity.ToTable("Renk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasMaxLength(50)
                .HasColumnName("adi");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.ToTable("Urunler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama)
                .HasMaxLength(50)
                .HasColumnName("aciklama");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .HasColumnName("ad");
            entity.Property(e => e.ColorId).HasColumnName("colorId");
            entity.Property(e => e.Fiyat).HasColumnName("fiyat");
            entity.Property(e => e.SizeId).HasColumnName("sizeId");

            entity.HasOne(d => d.Color).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Urunler_Renk");

            entity.HasOne(d => d.Size).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_Urunler_Boyut");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
