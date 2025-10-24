using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Base;
using PortfolioProject.core.Features.ApllicationUser.Commands;

namespace PortfolioProject.Controllers
{
    [Route("api/account")]
    [AllowAnonymous]
    public class AccountController : AppControllerBase
    {

        public AccountController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}
