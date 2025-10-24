using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasKey(s => s.SkillId);

            builder.HasOne(s => s.Portfolio)
                   .WithMany(p => p.Skills)
                   .HasForeignKey(s => s.PortfolioId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.SkillName).HasMaxLength(20).IsRequired();
        }
    }
}
