using Microsoft.EntityFrameworkCore;
using Shipping_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipment_Product>()
                .HasOne(s => s.Shipment)
                .WithMany(sp => sp.Shipment_Products)
                .HasForeignKey(si => si.ShipmentId);

            modelBuilder.Entity<Shipment_Product>()
               .HasOne(p => p.Product)
               .WithMany(sp => sp.Shipment_Products)
               .HasForeignKey(pi => pi.ProductId);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Shipment_Product> Shipments_Products { get; set; }

    }
}
