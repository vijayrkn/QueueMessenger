#nullable disable
using MessageModels;
using Microsoft.EntityFrameworkCore;

namespace MessageRetrieverAPI.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext (DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<MessageModels.Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("OrderContainer");
            modelBuilder.Entity<Order>()
                .ToContainer("OrderContainer");
            modelBuilder.Entity<Order>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Order>()
                .HasPartitionKey(o => o.TrackingId);
        }
    }
}
