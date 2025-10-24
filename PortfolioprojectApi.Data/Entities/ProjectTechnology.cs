namespace PortfolioProject.Data.Entities
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }
        public string TechnologyName { get; set; }

        // Foreign Key & Navigation
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
