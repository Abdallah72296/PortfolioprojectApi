namespace PortfolioProject.Data.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; } // Nullable for "Present"
        public bool IsCurrent { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        // Foreign Key & Navigation
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
