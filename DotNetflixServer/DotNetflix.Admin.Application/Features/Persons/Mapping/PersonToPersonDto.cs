using Domain.Entities;
using DotNetflix.Admin.Application.Features.Persons.Shared;

namespace DotNetflix.Admin.Application.Features.Persons.Mapping;

public static class PersonToPersonDto
{
    public static PersonDto ToPersonsDto(this Person person)
    {
        return new PersonDto(person.Id, person.Name, person.Photo);
    }
}