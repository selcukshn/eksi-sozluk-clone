using Api.Controllers.Base;
using Common.Models.Command;
using Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : BaseApiController
    {
        public EntryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("sidebar")]
        public async Task<IActionResult> GetSidebarEntities([FromQuery] SidebarEntitiesQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EntryCreateCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}