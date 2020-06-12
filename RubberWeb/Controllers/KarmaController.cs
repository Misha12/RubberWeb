using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            foreach (var item in data.Data)
            {
                var user = users.Find(o => o.ID == item.UserID);

                if (user == null)
                    user = new SimpleUserInfo() { ID = item.UserID };

                item.User = user;
            }

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
