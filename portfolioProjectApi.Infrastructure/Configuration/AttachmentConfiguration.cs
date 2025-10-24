using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioProject.Data.Entities;

namespace PortfolioProject.Infrastructure.Configuration
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachments>
    {
        public void Configure(EntityTypeBuilder<Attachments> builder)
        {
            builder.HasKey(a => a.AttachmentId);

            builder.Property(a => a.FilePath).HasMaxLength(512).IsRequired();
            builder.Property(a => a.FileName).HasMaxLength(256).IsRequired();

            // 💡 One-to-Many Relationship: Attachment has one Project
            builder.HasOne(a => a.Project)
                   .WithMany(p => p.ProjectFiles)
                   .HasForeignKey(a => a.ProjectId)
                   .IsRequired(false) // ProjectId is nullable
                   .OnDelete(DeleteBehavior.SetNull); // Set FK to NULL if Project is deleted
        }
    }
}
