using KM.Application.Utilities;
using Microsoft.AspNetCore.Identity;

namespace KM.Application.Authorization
{
    public static class AppPermission
    {
        public const string Song_Create = nameof(Song_Create);
        public const string Song_Edit = nameof(Song_Edit);
        public const string Song_Delete = nameof(Song_Delete);
        public const string Song_Read = nameof(Song_Read);

        public const string Genre_Create = nameof(Genre_Create);
        public const string Genre_Edit = nameof(Genre_Edit);
        public const string Genre_Delete = nameof(Genre_Delete);
        public const string Genre_Read = nameof(Genre_Read);

        public const string Singer_Create = nameof(Singer_Create);
        public const string Singer_Edit = nameof(Singer_Edit);
        public const string Singer_Delete = nameof(Singer_Delete);
        public const string Singer_Read = nameof(Singer_Read);

        public const string Playlist_Create = nameof(Playlist_Create);
        public const string Playlist_Edit = nameof(Playlist_Edit);
        public const string Playlist_Delete = nameof(Playlist_Delete);
        public const string Playlist_Read = nameof(Playlist_Read);

        public const string User_Create = nameof(User_Create);
        public const string User_Edit = nameof(User_Edit);
        public const string User_Delete = nameof(User_Delete);
        public const string User_Read = nameof(User_Read);

        public const string Role_Create = nameof(Role_Create);
        public const string Role_Edit = nameof(Role_Edit);
        public const string Role_Delete = nameof(Role_Delete);
        public const string Role_Read = nameof(Role_Read);
        public const string Role_ChangePermission = nameof(Role_ChangePermission);

        public const string VipPackage_Create = nameof(VipPackage_Create);
        public const string VipPackage_Edit = nameof(VipPackage_Edit);
        public const string VipPackage_Delete = nameof(VipPackage_Delete);
        public const string VipPackage_Read = nameof(VipPackage_Read);


        public const string Access_Admin = nameof(Access_Admin);

        public static List<IdentityRoleClaim<string>> adminClaims = new List<IdentityRoleClaim<string>>()
        {
            //song
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Song_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Song_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Song_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Song_Read},

            //genre
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Genre_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Genre_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Genre_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Genre_Read},


            // singer
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Singer_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Singer_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Singer_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Singer_Read},


            // playlistt
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Playlist_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Playlist_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Playlist_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Playlist_Read},


            // user
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=User_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=User_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=User_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=User_Read},


            // role
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Role_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Role_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Role_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Role_Read},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Role_ChangePermission},

            // vip package
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=VipPackage_Create},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=VipPackage_Edit},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=VipPackage_Delete},
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=VipPackage_Read},



            // access admin page
            new IdentityRoleClaim<string> {ClaimType=SD.Permission, ClaimValue=Access_Admin},
        };
    }
}
