using Supplier_API_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Supplier_API_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<QuoteItem> QuoteItems { get; set; }
    }
}