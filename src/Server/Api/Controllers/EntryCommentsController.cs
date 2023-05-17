using Api.Controllers.Base;
using Common.Models.Queries;
using Common.Models.Queries.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/entrycomments")]
    public class EntryCommentsController : BaseApiController
    {
        public EntryCommentsController(IMediator mediator) : base(mediator) { }

        [HttpGet("{entryId}")]
        public async Task<IActionResult> GetComments([FromQuery] PagedQuery query, Guid entryId)
        {
            return Ok(await base.Mediator.Send(new EntryCommentsQuery() { EntryId = entryId, UserId = query.UserId, Current = query.Current, Take = query.Take }));
        }
    }
}