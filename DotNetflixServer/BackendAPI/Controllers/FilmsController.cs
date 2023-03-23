﻿using System.Collections;
using BackendAPI.Dto;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

[ApiController]
[Route("/")]
public class FilmsController : ControllerBase
{
    private readonly IFilmProvider _filmProvider;

    public FilmsController(IFilmProvider filmProvider)
    {
        _filmProvider = filmProvider;
    }

    [HttpGet]
    public IEnumerable GetALlFilms()
    {
        return _filmProvider.GetAllFilms();
    }
    
    [HttpGet("/search")]
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(
        [FromQuery] string? type,
        [FromQuery] string? name, 
        [FromQuery] int? year, 
        [FromQuery] string? country,
        [FromQuery(Name = "genre")] string[]? genres,
        [FromQuery(Name = "actor")] string[]? actors,
        [FromQuery] string? director)
    {
        return _filmProvider.GetFilmsBySearch(type, name, year, country, genres, actors, director);
    }
}