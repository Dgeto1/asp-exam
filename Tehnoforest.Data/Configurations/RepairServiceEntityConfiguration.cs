using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tehnoforest.Data.Models;

namespace Tehnoforest.Data.Configurations
{
    public class RepairServiceEntityConfiguration : IEntityTypeConfiguration<RepairServiceProduct>
    {
        public void Configure(EntityTypeBuilder<RepairServiceProduct> builder)
        {
            builder.HasOne(b => b.User)
                .WithMany(u => u.RepairServiceProducts)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
