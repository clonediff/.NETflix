using DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;
using DotNetflix.Admin.Application.Features.Films.Commands.DeleteFilm;
using DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsCount;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsFiltered;
using DotNetflix.Admin.Application.Shared;
using DotNetflixAdminAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Manager")]
public class FilmsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFileService _fileService;

    public FilmsController(IMediator mediator, IFileService fileService)
    {
        _mediator = mediator;
        _fileService = fileService;
    }

    [HttpGet("[action]")]
    public async Task<int> GetFilmsCountAsync()
    {
        var query = new GetFilmsCountQuery();
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddFilmAsync(
        [FromForm] AddFilmDto dto,
        [FromForm] IEnumerable<IFormFile> trailers,
        [FromForm] IEnumerable<IFormFile> posters)
    {
        var command = dto.ToAddFilmCommand();
        var response = await _mediator.Send(command);

        await _fileService.AddFilesAsync(response.MovieId, trailers.Concat(posters),
            command.TrailersMetaData
                .Zip(response.TrailerIds, (x, y) => $"{y}{x.FileName}")
                .Concat(command.PostersMetaData.Zip(response.PosterIds, (x, y) => $"{y}{x.FileName}"))
                .ToList());
        
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<PaginationDataDto<EnumDto<int>>> GetFilmsFilteredAsync(
        [FromQuery] string? name, 
        [FromQuery] int? page = 1, 
        [FromQuery] int? size = 25)
    {
        var query = new GetFilmsFilteredQuery(name, page!.Value, size!.Value);
        return await _mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmById([FromQuery] int id)
    {
        var query = new GetFilmByIdQuery(id);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success: Ok,
            failure: BadRequest);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var command = new DeleteFilmCommand(id);
        await _mediator.Send(command);

        await _fileService.DeleteAllMovieFilesAsync(id);
        
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAsync(
        [FromForm] UpdateFilmDto dto,
        [FromForm] IEnumerable<IFormFile> trailers, 
        [FromForm] IEnumerable<IFormFile> posters)
    {
        var command = dto.ToUpdateFilmCommand();
        var metaDataIds = await _mediator.Send(command);

        await _fileService.DeleteFilesAsync(dto.Id, (dto.FilesToDelete ?? Enumerable.Empty<string>()).ToList());
        await _fileService.AddFilesAsync(dto.Id, trailers.Concat(posters), 
            (dto.FilesToAdd ?? Enumerable.Empty<string>())
                .Where(x => !x.StartsWith('.'))
                .Concat((dto.FilesToAdd ?? Enumerable.Empty<string>())
                    .Where(x => x.StartsWith('.'))
                    .Zip(metaDataIds, (x, y) => $"{y}{x}"))
                .ToList());
        
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmDetails([FromQuery] int id)
    {
        var query = new GetFilmDetailsQuery(id);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success: Ok,
            failure: BadRequest);
    }
}