namespace PortfolioProject.Data.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }

        // Foreign Key to AspNetUsers (Identity)
        public string UserId { get; set; }

        // Public Link Identifier
        public string CustomUsername { get; set; }

        // Core Data

        public string FullName { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public int? CvAttachmentId { get; set; }
        public Attachments CvAttachment { get; set; }

        public int? ProfileImageAttachmentId { get; set; }
        public Attachments ProfileImageAttachment { get; set; }

        // Navigation Properties (Collections)
        public ICollection<Skills> Skills { get; set; } = new List<Skills>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
