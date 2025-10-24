using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.PortfolioId);

            builder.HasOne(p => p.CvAttachment)
                   .WithOne()
                   .HasForeignKey<Portfolio>(p => p.CvAttachmentId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProfileImageAttachment)
                   .WithOne()
                   .HasForeignKey<Portfolio>(p => p.ProfileImageAttachmentId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<IdentityUser>()
                   .WithOne()
                   .HasForeignKey<Portfolio>(p => p.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.CustomUsername).IsUnique();
        }
    }
}
