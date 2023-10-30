using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class AddFilmCrewDtoToPersonProfession
{
    public static PersonProffessionInMovie ToPersonProfession(this AddOrUpdateFilmCrewDto dto)
    {
        return new PersonProffessionInMovie
        {
            ProfessionId = dto.ProfessionId,
            PersonId = dto.Id,
            Person = dto.Id != 0
                ? null!
                : new Person
                {
                    Id = dto.Id,
                    Name = dto.Name!,
                    Photo = dto.Photo,
                }
        };
    }
}
