using Api.Controllers.Base;
using Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryCommentsController : BaseApiController
    {
        public EntryCommentsController(IMediator mediator) : base(mediator) { }

        [HttpGet("{entryId}")]
        public async Task<IActionResult> GetComments(Guid entryId, [FromQuery] Guid userId)
        {
            return Ok(await base.Mediator.Send(new EntryCommentsQuery() { EntryId = entryId, UserId = userId }));
        }
    }
}