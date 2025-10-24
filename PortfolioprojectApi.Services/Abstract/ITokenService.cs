namespace PortfolioProject.Services.Abstract
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(Microsoft.AspNetCore.Identity.IdentityUser user);
    }
}
