using Microsoft.EntityFrameworkCore;
namespace ECommerce.Models
{
    public class EcommerceDbContext : DbContext
    {
    // base() calls the parent class' constructor passing the "options" parameter along
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }
            public DbSet<Product> products { get; set; }
            public DbSet<Category> categories { get; set; }
            public DbSet<ProductCategory> productcategories { get; set; }
            public DbSet<Image> images { get; set; }
            public DbSet<OrderProduct> orderproducts { get; set; }
            public DbSet<Order> orders { get; set; }
            public DbSet<ShippingAddress> shippingaddresses { get; set; }
            public DbSet<BillingAddress> billingaddresses { get; set; }
            public DbSet<PaymentMethod> paymentmethods { get; set; }
            public DbSet<User> users { get; set; }
            public DbSet<Cart> carts { get; set; }
    }
}