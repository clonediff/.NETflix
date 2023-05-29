﻿using Contracts.Admin.Films;
using DataAccess;
using Mappers.Admin;
using Microsoft.EntityFrameworkCore;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class FilmPersonService : IFilmPersonService
{
    private readonly ApplicationDBContext _dbContext;

    public FilmPersonService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<PersonDto> GetAll()
    {
        return _dbContext.Persons
            .AsNoTracking()
            .Select(p => p.ToPersonsDto());
    }
}