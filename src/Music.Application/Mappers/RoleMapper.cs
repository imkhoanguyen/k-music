using Music.Application.DTOs.Roles;
using Music.Domain.Entities;

namespace Music.Application.Mappers
{
    public class RoleMapper
    {
        public static RoleDto EntityToRoleDto(AppRole appRole)
        {
            return new RoleDto
            {
                Id = appRole.Id,
                Name = appRole.Name,
                Description = appRole.Description,
            };
        }
    }
}
