using Contracts.Admin.DataRepresentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Manager")]
public class EnumsController : Controller
{
    private readonly IEnumService _enumService;

    public EnumsController(IEnumService enumService)
    {
        _enumService = enumService;
    }

    [HttpGet("[action]")]
    public IDictionary<string, IEnumerable<EnumDto<int>>> GetAll()
    {
        return _enumService.GetAll();
    }

    [HttpGet("[action]")]
    public IEnumerable<EnumDto<int>> GetTypes()
    {
        return _enumService.GetTypes();
    }

    [HttpGet("[action]")]
    public IEnumerable<EnumDto<int>> GetCountries()
    {
        return _enumService.GetCountries();
    }

    [HttpGet("[action]")]
    public IEnumerable<EnumDto<int>> GetGenres()
    {
        return _enumService.GetGenres();
    }

    [HttpGet("[action]")]
    public IEnumerable<EnumDto<int>> GetCategories()
    {
        return _enumService.GetCategories();
    }

    [HttpGet("[action]")]
    public IEnumerable<EnumDto<int>> GetProfessions()
    {
        return _enumService.GetProfessions();
    }
}