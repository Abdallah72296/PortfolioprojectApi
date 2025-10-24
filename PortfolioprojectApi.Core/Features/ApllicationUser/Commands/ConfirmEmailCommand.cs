using MediatR;
using Microsoft.AspNetCore.Identity;
using PortfolioProject.core.Responses;
using PortfolioProject.Services.Abstract;

namespace PortfolioProject.core.Features.ApllicationUser.Commands
{
    public record ConfirmEmailCommand(string UserId, string Token)
        : IRequest<ApiResponse<string>>;

    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, ApiResponse<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public ConfirmEmailHandler(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return ApiResponse<string>.Failure("Verification failed: User not found.");

            var decodedToken = Uri.UnescapeDataString(request.Token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return ApiResponse<string>.Failure($"Email verification failed: {string.Join(", ", errors)}");
            }

            var jwtToken = await _tokenService.CreateTokenAsync(user);

            return ApiResponse<string>.Success(jwtToken, "Email confirmed successfully. You are now authenticated.");
        }
    }
}
