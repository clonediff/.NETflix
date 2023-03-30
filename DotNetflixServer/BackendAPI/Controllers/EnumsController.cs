using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnumsController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        
        public EnumsController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet("[action]")]
        public IDictionary<string, IEnumerable<string>> GetAll()
        {
            return new Dictionary<string, IEnumerable<string>>
            {
                ["types"] = _dbContext.Types.Select(x => x.Name),
                ["countries"] = _dbContext.Countries.Select(x => x.Name),
                ["genres"] = _dbContext.Genres.Select(x => x.Name),
                ["categories"] = _dbContext.Categories.Select(x => x.Name)
            };
        }
    }
}
