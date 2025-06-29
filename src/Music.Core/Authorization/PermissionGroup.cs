﻿using Music.Core.DTOs.Auth;

namespace Music.Core.Authorization
{
    public class PermissionGroup
    {
        public static List<PermissionGroupDto> AllPermissionGroups = new List<PermissionGroupDto>() {
            new PermissionGroupDto
            {
                GroupName = "Quản lý bài hát",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Tạo bài hát", ClaimValue = AppPermission.Song_Create},
                    new PermissionItemDto {Name = "Sửa bài hát", ClaimValue = AppPermission.Song_Edit},
                    new PermissionItemDto {Name = "Xóa bài hát", ClaimValue = AppPermission.Song_Delete},
                }
            },

            new PermissionGroupDto
            {
                GroupName = "Quản lý thể loại",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Tạo thể loại", ClaimValue = AppPermission.Genre_Create},
                    new PermissionItemDto {Name = "Sửa thể loại", ClaimValue = AppPermission.Genre_Edit},
                    new PermissionItemDto {Name = "Xóa thể loại", ClaimValue = AppPermission.Genre_Delete},
                }
            },

            new PermissionGroupDto
            {
                GroupName = "Quản lý ca sĩ",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Tạo ca sĩ", ClaimValue = AppPermission.Singer_Create},
                    new PermissionItemDto {Name = "Sửa ca sĩ", ClaimValue = AppPermission.Singer_Edit},
                    new PermissionItemDto {Name = "Xóa ca sĩ", ClaimValue = AppPermission.Singer_Delete},
                }
            },


            new PermissionGroupDto
            {
                GroupName = "Quản lý người dùng",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Xem người dùng", ClaimValue = AppPermission.User_Read},
                    new PermissionItemDto {Name = "Tạo người dùng", ClaimValue = AppPermission.User_Create},
                    new PermissionItemDto {Name = "Xóa người dùng", ClaimValue = AppPermission.User_Delete},
                }
            },

            new PermissionGroupDto
            {
                GroupName = "Quản lý quyền",
                Permissions = new List<PermissionItemDto>
                {
                   new PermissionItemDto {Name = "Xem quyền", ClaimValue = AppPermission.Role_Read},
                    new PermissionItemDto {Name = "Tạo quyền", ClaimValue = AppPermission.Role_Create},
                    new PermissionItemDto {Name = "Sửa quyền quyền", ClaimValue = AppPermission.Role_Edit},
                    new PermissionItemDto {Name = "Xóa quyền", ClaimValue = AppPermission.Role_Delete},
                    new PermissionItemDto {Name = "Thay đổi chức năng", ClaimValue = AppPermission.Role_ChangePermission}

                }
            },

            new PermissionGroupDto
            {
                GroupName = "Quyền truy cập",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Trang Admin", ClaimValue = AppPermission.Access_Admin},
                }
            },

            new PermissionGroupDto
            {
                GroupName = "Quản lý gói đăng ký",
                Permissions = new List<PermissionItemDto>
                {
                    new PermissionItemDto {Name = "Tạo gói", ClaimValue = AppPermission.VipPackage_Create},
                    new PermissionItemDto {Name = "Sửa gói", ClaimValue = AppPermission.VipPackage_Edit},
                    new PermissionItemDto {Name = "Xóa gói", ClaimValue = AppPermission.VipPackage_Delete},
                }
            },
        };
    }
}
