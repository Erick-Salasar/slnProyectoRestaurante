using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjProyectoRestaurante.Models;
using Microsoft.EntityFrameworkCore;


namespace prjProyectoRestaurante.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {

        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Persona>().HasMany(g => g.Generos).WithOne(Genero => Genero.Personas);
           //modelBuilder.Entity<Persona>().HasMany()
            //modelBuilder.Entity<Genero>().HasMany(p => p.Personas).WithOne(Persona => Persona.Generos);
            //modelBuilder.Entity<Personas>().HasMany(re => re.Relaciones).WithOne(Relacion => Relacion.Personas);
            //modelBuilder.Entity<Rol>().HasMany(Re => Re.Relaciones).WithOne(Relacion => Relacion.Rol);
            //modelBuilder.Entity<Relacion>().HasMany(r => r.Roles).WithOne(Rol => Rol.Relaciones );

            
            modelBuilder.Entity<Persona>()
                .Property(e => e.Cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsFixedLength()
                .IsUnicode(false);


        }*/

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EstadoMesa> EstadoMesas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<InventarioIngrediente> InventarioIngredientes { get; set; }

        public DbSet<InventarioProdu> InventarioProdus { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoIngrediente> ProductoIngredientes { get; set; }
        public DbSet<ReservaMesa> ReservaMesas { get; set; }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Relacion> Relaciones { get; set; }

    }
}