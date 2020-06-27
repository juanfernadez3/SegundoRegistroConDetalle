using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SegundoRegistroConDetalle.Models;

namespace SegundoRegistroConDetalle.Dal
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data/BDRegistroConDetalle2.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombre = "JuanSuplidor"
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductosId = 1,
                Descripcion = "Mascarillas",
                Costo = 15,
                Inventario = 1000,
                SuplidorId = 1
            });
        }
    }
}
