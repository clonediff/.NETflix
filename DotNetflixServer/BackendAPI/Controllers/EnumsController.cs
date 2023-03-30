using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnumsController : Controller
    {
        private ApplicationDBContext _dbContext;
        public EnumsController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet("[action]")]
        public IDictionary<string, IEnumerable<string>> GetAll()
        {
            var res = new Dictionary<string, IEnumerable<string>>();
            res["types"] = _dbContext.Types.Select(x => x.Name);
            res["countries"] = _dbContext.Countries.Select(x => x.Name);
            res["genres"] = _dbContext.Genres.Select(x => x.Name);
            res["categories"] = _dbContext.Categories.Select(x => x.Name);
            return res;
        }
    }
}
