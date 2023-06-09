using Api.Controllers.Base;
using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Queries.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/entry")]
    public class EntryController : BaseApiController
    {
        public EntryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllEntry([FromQuery] int count)
        {
            return Ok(await base.Mediator.Send(new AllEntryQuery() { Count = count }));
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> GetEntry([FromQuery] Guid? userId, string url)
        {
            return Ok(await base.Mediator.Send(new SingleEntryQuery() { Url = url, UserId = userId }));
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetUserEntries(Guid userId, [FromQuery] int skip)
        {
            return Ok(await base.Mediator.Send(new UserEntriesQuery() { UserId = userId, Skip = skip, Count = 5 }));
        }

        [HttpGet]
        [Route("user/favorite/{userId}")]
        public async Task<IActionResult> GetUserFavorites(Guid userId, [FromQuery] int skip)
        {
            return Ok(await base.Mediator.Send(new UserFavoritesQuery() { UserId = userId, Skip = skip, Count = 5 }));
        }

        [HttpGet]
        [Route("sidebar")]
        public async Task<IActionResult> GetSidebarEntries([FromQuery] SidebarEntriesQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpGet]
        [Route("main")]
        public async Task<IActionResult> GetMainPageEntries([FromQuery] MainPageEntriesQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpGet]
        [Route("search/{value}")]
        public async Task<IActionResult> Search(string value, [FromQuery] int count)
        {
            return Ok(await base.Mediator.Send(new SearchQuery() { Value = value, Count = count }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EntryCreateCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }

        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> VoteAsync(EntryVoteCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> FavoriteAsync(EntryFavoriteCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}