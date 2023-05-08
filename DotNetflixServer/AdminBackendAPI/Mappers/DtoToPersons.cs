using AdminBackendAPI.Dto;
using DataAccess.Entities.BusinessLogic;
using System.Runtime.CompilerServices;

namespace AdminBackendAPI.Mappers;

public static class DtoToPersons
{
    public static PersonProffessionInMovie ToPersonProfession(this InsertPersonDto dto)
    {
        return new PersonProffessionInMovie
        {

        };
    }
}
