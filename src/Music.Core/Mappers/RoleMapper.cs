using Music.Core.DTOs.Roles;
using Music.Core.Entities;

namespace Music.Core.Mappers
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
