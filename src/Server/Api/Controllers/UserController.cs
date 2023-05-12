using Api.Controllers.Base;
using Common.Models.Command;
using Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}