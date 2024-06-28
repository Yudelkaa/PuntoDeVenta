using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;

namespace PuntoDeVenta_Cliente.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<VentasDetalle> VentasDetalles { get; set; }

    
        
    }
}
