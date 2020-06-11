using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubberWeb.Models;
using RubberWeb.Models.Karma;
using RubberWeb.Services;

namespace RubberWeb.Controllers
{
    [Route("api/karma")]
    [ApiController]
    public class KarmaController : Controller
    {
        private AppDbContext Context { get; }
        private GrillBotService GrillBotService { get; }

        public KarmaController(AppDbContext context, GrillBotService grillBotService)
        {
            Context = context;
            GrillBotService = grillBotService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedData<KarmaItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetData([FromQuery] PaginatedRequest request)
        {
            var query = Context.Karma.AsQueryable();
            query = request.Sort == PageSort.Asc ? query.OrderBy(o => o.Karma) : query.OrderByDescending(o => o.Karma);
            var data = PaginatedData<KarmaItem>.Create(query, request, entity => new KarmaItem(entity));
            
            var userIds = data.Data.Select(o => o.UserID).ToList();
            var users = await GrillBotService.GetUsersSimpleInfoBatchAsync(userIds);

            foreach(var item in data.Data)
            {
                item.User = users.Find(o => o.ID == item.UserID);
            }

            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
                GrillBotService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
