namespace PortfolioProject.Data.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Summary { get; set; }
        public string ProjectUrl { get; set; }
        public string Category { get; set; }
        public int Order { get; set; }

        // Foreign Key & Navigation
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        // Navigation Properties (Collections)
        public ICollection<Attachments> ProjectFiles { get; set; } = new List<Attachments>();
        public ICollection<ProjectTechnology> Technologies { get; set; } = new List<ProjectTechnology>();
        public ICollection<ProjectHighlight> Highlights { get; set; } = new List<ProjectHighlight>();
    }
}
