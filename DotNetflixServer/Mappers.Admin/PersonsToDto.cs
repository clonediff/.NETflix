using Contracts.Admin.Films;
using Domain.Entities;

namespace Mappers.Admin;

public static class PersonsToDto
{
    public static PersonDto ToPersonsDto(this Person person)
    {
        return new PersonDto(person.Id, person.Name, person.Photo);
    }
}