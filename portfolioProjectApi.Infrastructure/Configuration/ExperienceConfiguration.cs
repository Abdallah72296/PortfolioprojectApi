using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {

            builder.HasKey(e => e.ExperienceId);

            builder.HasOne(e => e.Portfolio)
                   .WithMany(p => p.Experiences)
                   .HasForeignKey(e => e.PortfolioId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.JobTitle).HasMaxLength(100).IsRequired();
            builder.Property(e => e.CompanyName).HasMaxLength(100).IsRequired();
        }
    }
}
