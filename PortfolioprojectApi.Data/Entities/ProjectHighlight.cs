using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Data.Entities
{
    public class ProjectHighlight
    {
        [Key]
        public int HighlightId { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        // Foreign Key & Navigation
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
