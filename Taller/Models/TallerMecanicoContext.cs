using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taller.Models;

public partial class TallerMecanicoContext : DbContext
{
    public TallerMecanicoContext()
    {
    }

    public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Smecanico> Smecanicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NAHE9NT;Database=TallerMecanico;Trusted_Connection=True;TrustServerCertificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdCarro)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCarro");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("idCliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("apellido");
            entity.Property(e => e.IdCarro).HasColumnName("idCarro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Smecanico>(entity =>
        {
            entity.HasKey(e => e.IdMecanico);

            entity.ToTable("Smecanico");

            entity.Property(e => e.IdMecanico).HasColumnName("idMecanico");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("apellido");
            entity.Property(e => e.Herramientas)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("herramientas");
            entity.Property(e => e.IdCarro).HasColumnName("idCarro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
