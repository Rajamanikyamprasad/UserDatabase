namespace UserDatabase.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure logging to console
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

        base.OnConfiguring(optionsBuilder);
    }



    public DbSet<Address> Address { get; set; }
    public DbSet<OrderedItem> OrderedItem { get; set; }
    public DbSet<ShippingOrder> ShippingOrder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<OrderedItem>()
            .HasOne(oi => oi.ShippingOrder)
            .WithMany(so => so.OrderedItem)
            .HasForeignKey(oi => oi.order_id);

        base.OnModelCreating(modelBuilder);
    }

}



