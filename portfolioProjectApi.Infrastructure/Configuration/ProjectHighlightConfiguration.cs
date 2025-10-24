using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class ProjectHighlightConfiguration : IEntityTypeConfiguration<ProjectHighlight>
    {
        public void Configure(EntityTypeBuilder<ProjectHighlight> builder)
        {
            builder.HasKey(h => h.HighlightId);

            builder.HasOne(h => h.Project)
                   .WithMany(p => p.Highlights)
                   .HasForeignKey(h => h.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
