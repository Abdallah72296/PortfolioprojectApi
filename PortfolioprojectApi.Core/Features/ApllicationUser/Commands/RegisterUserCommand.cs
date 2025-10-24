using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortfolioProject.core.Responses;
using PortfolioProject.Services.Abstract;

namespace PortfolioProject.core.Features.ApllicationUser.Commands
{
    public record RegisterUserCommand(string Email, string Password)
      : IRequest<ApiResponse<string>>;

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ApiResponse<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailServices _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterUserHandler(UserManager<IdentityUser> userManager,
                                     IEmailServices emailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                return ApiResponse<string>.Failure("A user with this email already exists.");

            var newUser = new IdentityUser { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
                return ApiResponse<string>.Failure(result.Errors.Select(e => e.Description));

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            var otpCode = await _userManager.GenerateTwoFactorTokenAsync(newUser, "Email");
            var encodedToken = Uri.EscapeDataString(confirmationToken);
            var resquestAccessor = _httpContextAccessor.HttpContext.Request;
            var confirmationLink = $"https://resquestAccessor/api/account/confirm-email?userId={newUser.Id}&token={encodedToken}";

            try
            {
                await _emailService.SendEmailAsync(
                    newUser.Email,
                    "Account Activation Required",
                    $"Welcome! Click here to verify your email: <a href=\"{confirmationLink}\">{confirmationLink}</a>"
                );
            }
            catch (Exception)
            {
                return ApiResponse<string>.Failure("User registered successfully, but failed to send the verification email.");
            }

            return ApiResponse<string>.Success(null, "User registered. Check your email for the verification link.");
        }
    }
}
