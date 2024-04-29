using Application.Games.Queries.GetAvailableGames;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController
    {
        [HttpGet]        
        public async Task<ActionResult<AvailableGamesVm>> Index()
        {
            var vm = await Mediator.Send(new GetAvailableGamesQuery());

            return Ok(vm);
        }
    }
}
