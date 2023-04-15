using AdminBackendAPI.Dto;
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
        public IDictionary<string, IEnumerable<EnumDto>> GetAll()
        {
            return new Dictionary<string, IEnumerable<EnumDto>>
            {
                ["types"] = GetTypes(),
                ["countries"] = GetCountries(),
                ["genres"] = GetGenres(),
                ["categories"] = GetCategories(),
                ["professions"] = GetProfessions()
            };
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto> GetTypes()
        {
            return _dbContext.Types.Select(x => new EnumDto { Id = x.Id, Name = x.Name });
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto> GetCountries()
        {
            return _dbContext.Countries.Select(x => new EnumDto { Id = x.Id, Name = x.Name });
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto> GetGenres()
        {
            return _dbContext.Genres.Select(x => new EnumDto { Id = x.Id, Name = x.Name });
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto> GetCategories()
        {
            return _dbContext.Categories.Select(x => new EnumDto { Id = x.Id, Name = x.Name });
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto> GetProfessions()
        {
            return _dbContext.Professions.Select(x => new EnumDto { Id = x.Id, Name = x.Name });
        }
    }
}
