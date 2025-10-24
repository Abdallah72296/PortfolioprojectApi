namespace PortfolioProject.Data.Entities
{
    public class Skills
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillCategory { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        // Foreign Key & Navigation
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
