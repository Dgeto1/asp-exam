namespace Tehnoforest.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Tehnoforest.Data.Models;

    public class ProductsEntityConfiguration : IEntityTypeConfiguration<Product>
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
    }
}
