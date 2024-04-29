using Application.Tournaments.Commands.TournamentResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : BaseController
    {
        [HttpPost]        
        public async Task<ActionResult<TournamentResultVm>> Create([FromBody]IEnumerable<string> competitors)
        {
            var vm = await Mediator.Send(new TournamentResultCommand(competitors));

            return Ok(vm);
        }
    }
}
