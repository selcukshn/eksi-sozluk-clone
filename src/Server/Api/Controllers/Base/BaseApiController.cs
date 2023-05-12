using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}