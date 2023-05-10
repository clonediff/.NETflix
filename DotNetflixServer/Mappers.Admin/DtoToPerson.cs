using Contracts.Admin.Films;
using Domain.Entities;

namespace Mappers.Admin;

public static class DtoToPerson
{
    public static PersonProffessionInMovie ToPersonProfession(this AddFilmCrewDto dto)
    {
        return new PersonProffessionInMovie
        {
            ProfessionId = dto.Profession,
            PersonId = dto.Id,
            Person = dto.Id != 0
                ? null!
                : new Person
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Photo = dto.Photo,
                }
        };
    }
}
