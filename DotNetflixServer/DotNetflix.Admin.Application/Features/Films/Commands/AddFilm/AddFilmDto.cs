﻿using DotNetflix.Admin.Application.Features.Films.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

public record AddFilmDto(
    string Name, 
    int Year, 
    string? Description, 
    string? ShortDescription, 
    string? Slogan, 
    double? Rating, 
    int MovieLength, 
    int? AgeRating, 
    string? PosterUrl, 
    int Type, 
    int? Category, 
    uint? Budget, 
    string? BudgetCurrency, 
    uint? FeesRussia,
    string? FeesRussiaCurrency, 
    uint? FeesUsa, 
    string? FeesUsaCurrency, 
    uint? FeesWorld, 
    string? FeesWorldCurrency,
    int[] Countries, 
    int[] Genres, 
    AddSeasonDto[]? Seasons, 
    AddOrUpdateFilmCrewDto[] People);