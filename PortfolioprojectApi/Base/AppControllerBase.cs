using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.core.Responses;
using System.Net;

namespace PortfolioProject.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;
        public AppControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        #region Actions

        public ObjectResult NewResult<T>(ApiResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
        #endregion

    }
}
