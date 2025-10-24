namespace PortfolioProject.Services.Abstract
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
