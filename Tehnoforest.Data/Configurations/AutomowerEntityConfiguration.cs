namespace Tehnoforest.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Tehnoforest.Data.Models;

    public class AutomowerEntityConfiguration : IEntityTypeConfiguration<Automower>
    {
        public void Configure(EntityTypeBuilder<Automower> builder)
        {
            builder
                .HasOne(a => a.User)
                .WithMany(u => u.Automowers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<Chainsaw> builder)
        {
            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Chainsaws)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<GardenTractor> builder)
        {
            builder
                .HasOne(gt => gt.User)
                .WithMany(u => u.GardenTractors)
                .HasForeignKey(gt => gt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<GrassTrimmer> builder)
        {
            builder
                .HasOne(gt => gt.User)
                .WithMany(u => u.GrassTrimmers)
                .HasForeignKey(gt => gt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<LawnMower> builder)
        {
            builder
                .HasOne(lm => lm.User)
                .WithMany(u => u.LawnMowers)
                .HasForeignKey(lm => lm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
