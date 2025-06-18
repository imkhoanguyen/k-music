namespace KM.Application.DTOs.Auth
{
    public class PermissionGroupDto
    {
        public required string GroupName { get; set; }
        public List<PermissionItemDto> Permissions { get; set; } = [];
    }
}
