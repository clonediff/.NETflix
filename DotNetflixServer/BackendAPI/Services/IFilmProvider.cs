﻿using System.Collections;
using BackendAPI.Dto;
using BackendAPI.Dto.MoviePage;

namespace BackendAPI.Services;

public interface IFilmProvider
{
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director);
    public IEnumerable GetAllFilms();
    public Task<MovieForMoviePageDto?> GetFilmByIdAsync(int id);
}