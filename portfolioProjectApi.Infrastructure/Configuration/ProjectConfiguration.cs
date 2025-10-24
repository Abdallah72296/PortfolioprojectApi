using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.ProjectId);


            builder.HasMany(p => p.ProjectFiles)
                   .WithOne(a => a.Project)
                   .HasForeignKey(a => a.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
