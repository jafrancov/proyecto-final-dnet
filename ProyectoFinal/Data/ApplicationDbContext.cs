using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace ProyectoFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePedido>()
                .HasKey(dp => new { dp.PedidoID, dp.ProductoID });

            modelBuilder.Entity<DetallePedido>()
                .HasOne(pt => pt.Pedido)
                .WithMany(p => p.DetallePedido)
                .HasForeignKey(pt => pt.PedidoID);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dpp => dpp.Producto )
                .WithMany(p => p.DetallePedido)
                .HasForeignKey(pt => pt.ProductoID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        //public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<EstatusPedido> EstatusPedido { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Promociones> Promociones { get; set; }
    }
}
