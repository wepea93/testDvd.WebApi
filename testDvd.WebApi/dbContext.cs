using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using testDvd.WebApi.Models;

#nullable disable

namespace testDvd.WebApi
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=ASW4527\\MSSQL2016DEV;Database=testDvdLegado;Integrated Security=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("tipoDocumento");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.ToTable("detalleVenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodProducto).HasColumnName("codProducto");

                entity.Property(e => e.CodVenta).HasColumnName("codVenta");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precioUnitario");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleVenta_Producto");

                entity.HasOne(d => d.CodVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.CodVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleVenta_Venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("stock");

                entity.HasOne(d => d.CodProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("identificacion");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("razonSocial");

                entity.Property(e => e.Rut)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("rut");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefono");

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodCliente).HasColumnName("codCliente");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("descuento");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.ValorNeto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valorNeto");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valorTotal");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
