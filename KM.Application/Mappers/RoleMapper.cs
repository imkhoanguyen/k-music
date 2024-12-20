using KM.Application.DTOs.Roles;
using KM.Domain.Entities;

namespace KM.Application.Mappers
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
