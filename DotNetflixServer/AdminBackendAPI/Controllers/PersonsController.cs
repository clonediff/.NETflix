using AdminBackendAPI.Dto;
using AdminBackendAPI.Mappers;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PersonsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<PersonsDto> GetAll()
        {
            return _dbContext.Persons.Select(x => x.ToPersonsDto());
        }
    }
}
