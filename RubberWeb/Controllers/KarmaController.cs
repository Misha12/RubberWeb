using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using RubberWeb.Models;
using RubberWeb.Models.GrillBot;
using RubberWeb.Models.Karma;
using RubberWeb.Services;

namespace RubberWeb.Controllers
{
    [Route("api/karma")]
    [ApiController]
    public class KarmaController : Controller
    {
        private AppDbRepository Repository { get; }
        private GrillBotService GrillBotService { get; }

        public KarmaController(AppDbRepository repository, GrillBotService grillBotService)
        {
            Repository = repository;
            GrillBotService = grillBotService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedData<KarmaItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetData([FromQuery] PaginatedRequest request)
        {
            var query = Repository.GetKarma(request.Sort);
            var data = PaginatedData<KarmaItem>.Create(query, request, entity => new KarmaItem(entity));

            var users = await GrillBotService.GetUsersSimpleInfoBatchAsync(data.Data.Select(o => o.UserID));

            var position = PaginationHelper.CountSkipValue(request) + 1;
            foreach (var item in data.Data)
            {
                item.User = users.Find(o => o.ID == item.UserID);

                item.Position = position;
                position++;
            }

            data.Data = data.Data.Where(o => o.User != null).ToList();
            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
                GrillBotService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
