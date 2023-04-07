using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AdminBackendAPI.Controllers
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
                ["types"] = GetTypes(),
                ["countries"] = GetCountries(),
                ["genres"] = GetGenres(),
                ["categories"] = GetCategories(),
                ["professions"] = GetProfessions()
            };
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetTypes()
        {
            return _dbContext.Types.Select(x => x.Name);
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetCountries()
        {
            return _dbContext.Countries.Select(x => x.Name);
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetGenres()
        {
            return _dbContext.Genres.Select(x => x.Name);
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetCategories()
        {
            return _dbContext.Categories.Select(x => x.Name);
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetProfessions()
        {
            return _dbContext.Professions.Select(x => x.Name);
        }
    }
}
