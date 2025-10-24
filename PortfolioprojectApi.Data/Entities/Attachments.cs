namespace PortfolioProject.Data.Entities
{
    public class Attachments
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; } // The actual path/URL
        public string OriginalFileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public DateTime UploadedAt { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
