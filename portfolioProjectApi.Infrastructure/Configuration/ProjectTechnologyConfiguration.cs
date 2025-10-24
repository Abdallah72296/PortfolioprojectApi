using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class ProjectTechnologyConfiguration : IEntityTypeConfiguration<ProjectTechnology>
    {
        public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
        {
            builder.HasKey(pt => pt.ProjectTechnologyId);

            builder.HasOne(pt => pt.Project)
                   .WithMany(p => p.Technologies)
                   .HasForeignKey(pt => pt.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
