﻿using System.Collections;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;

namespace Services.FilmService;

public interface IFilmService
{
    public Task<int> GetFilmsCountAsync();
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director);
    public IEnumerable GetAllFilms();
    public Task<MovieForMoviePageDto?> GetFilmByIdAsync(int id);
    public Task AddFilmAsync(MovieInfo movieInfo);
    Task<PaginationDataDto<string>> GetFilmsFilteredAsync(int page, string? name);
}