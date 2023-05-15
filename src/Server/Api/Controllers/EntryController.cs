using Api.Controllers.Base;
using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Queries.Base;
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
        public async Task<IActionResult> GetAllEntry([FromQuery] int count)
        {
            return Ok(await base.Mediator.Send(new AllEntryQuery() { Count = count }));
        }
        [HttpGet("{url}")]
        public async Task<IActionResult> GetEntry([FromQuery] Guid userId, string url)
        {
            return Ok(await base.Mediator.Send(new SingleEntryQuery() { Url = url, UserId = userId }));
        }

        [HttpGet("comments")]
        public async Task<IActionResult> GetEntryComments([FromBody] EntryCommentsQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpGet]
        [Route("sidebar")]
        public async Task<IActionResult> GetSidebarEntities([FromQuery] SidebarEntitiesQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpGet]
        [Route("main")]
        public async Task<IActionResult> GetMainPageEntities([FromQuery] MainPageEntitiesQuery query)
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