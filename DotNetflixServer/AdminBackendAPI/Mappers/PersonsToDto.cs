using AdminBackendAPI.Dto;
using DataAccess.Entities.BusinessLogic;

namespace AdminBackendAPI.Mappers
{
    public static class PersonsToDto
    {
        public static PersonsDto ToPersonsDto(this Person person)
        {
            return new PersonsDto
            {
                Id = person.Id,
                Name = person.Name,
                Photo = person.Photo
            };
        }
    }
}
