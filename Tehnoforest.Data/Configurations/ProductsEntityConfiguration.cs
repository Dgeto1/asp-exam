namespace Tehnoforest.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Tehnoforest.Data.Models;

    public class ProductsEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(b => b.User)
                .WithMany(u => u.Products)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Property(p => p.IsAvailable)
               .HasDefaultValue(true);
        }
        /*public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasOne(d => d.Product)
                   .WithMany(d => d.User.ShoppingCartItems)
                   .HasForeignKey(p => p.ShoppingCartId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }*/
    }
}
