using Api.Controllers.Base;
using Common.Models.Command;
using Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserCreateCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}