using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ecommerse.Data
{
    public partial class DB_EcommerseContext : DbContext
    {
        public DB_EcommerseContext()
        {
        }

        public DB_EcommerseContext(DbContextOptions<DB_EcommerseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:ecommerseserver.database.windows.net,1433;Initial Catalog=DB_Ecommerse;Persist Security Info=False;User ID=jhernandezf;Password=BNcr1234*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdCarrito);

                entity.ToTable("Carrito");

                entity.Property(e => e.IdCarrito)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Carrito");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdArticulo).HasColumnName("id_Articulo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Categoria");

                entity.Property(e => e.DescripcionCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_Categoria");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Producto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_Producto");

                entity.Property(e => e.IdCategoria).HasColumnName("id_Categoria");

                entity.Property(e => e.PrecioProducto)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_Producto");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview);

                entity.ToTable("Review");

                entity.Property(e => e.IdReview)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Review");

                entity.Property(e => e.FechaReview)
                    .HasColumnType("date")
                    .HasColumnName("fecha_Review");

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuaro);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuaro)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Usuaro");

                entity.Property(e => e.ContrasenaUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasena_Usuario");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_Usuario");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
