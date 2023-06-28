using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDB_API.Models;

public partial class APIContext : DbContext
{
    public APIContext()
    {
    }

    public APIContext(DbContextOptions<APIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategorium> TbCategoria { get; set; }

    public virtual DbSet<TbDetalleVentum> TbDetalleVenta { get; set; }

    public virtual DbSet<TbPersona> TbPersonas { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbVentum> TbVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a9ac4d_proyectodb;User Id=db_a9ac4d_proyectodb_admin;Password=camilomoron1109; Trusted_Connection=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__TB_CATEG__4BD51FA58CB1718F");

            entity.ToTable("TB_CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CATEGORIA");
        });

        modelBuilder.Entity<TbDetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__TB_DETAL__49DABA0CB77C73A7");

            entity.ToTable("TB_DETALLE_VENTA");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("ID_DETALLE_VENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TbDetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_PRODUCTO");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TbDetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_VENTA");
        });

        modelBuilder.Entity<TbPersona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__TB_PERSO__78244149B6D1D5EF");

            entity.ToTable("TB_PERSONAS");

            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CLAVE");
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PERSONA");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TIPO_PERSONA");
            entity.Property(e => e.Usuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USUARIO");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__TB_PRODU__88BD0357767E4723");

            entity.ToTable("TB_PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.TbProductos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_CATEGORIA");
        });

        modelBuilder.Entity<TbVentum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__TB_VENTA__F3B6C1B4F1009DC5");

            entity.ToTable("TB_VENTA");

            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.EstadoVenta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_VENTA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.TotalVenta).HasColumnName("TOTAL_VENTA");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_CLIENTE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
