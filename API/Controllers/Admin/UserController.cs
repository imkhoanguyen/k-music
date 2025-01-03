using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Users;
using KM.Application.Interfaces;
using KM.Application.Parameters;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Domain.Enum;
using KM.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Admin
{
    public class UserController : BaseAdminApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICloudinaryService _cloudinaryService;
        public UserController(UserManager<AppUser> userManager, ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll([FromQuery] UserParams prm)
        {
            var query = _userManager.Users.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(prm.Search))
            {
                query = query.Where(u => u.PhoneNumber.Contains(prm.Search)
                || u.FullName.ToLower().Contains(prm.Search.ToLower())
                || u.UserName.ToLower().Contains(prm.Search.ToLower()));
            }

            if (!string.IsNullOrEmpty(prm.OrderBy))
            {
                query = prm.OrderBy switch
                {
                    "userName" => query.OrderBy(u => u.UserName),
                    "userName_desc" => query.OrderByDescending(u => u.UserName),
                    "email" => query.OrderBy(u => u.Email),
                    "email_desc" => query.OrderByDescending(u => u.Email),
                    "fullName" => query.OrderBy(u => u.FullName),
                    "fullName_desc" => query.OrderByDescending(u => u.FullName),
                    "created" => query.OrderBy(u => u.Created),
                    "created_desc" => query.OrderByDescending(u => u.Created),
                    _ => query.OrderBy(u => u.Created)
                };
            }

            var count = await query.CountAsync();

            var users = await query.Skip((prm.PageNumber - 1) * prm.PageSize)
                .Take(prm.PageSize)
                .ToListAsync();

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var dto = new UserDto
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Gender = user.Gender.ToString(),
                    ImgUrl = user.ImgUrl,
                    Created = user.Created,
                    Role = roles[0],
                    Email = user.Email,
                    IsLooked = user.LockoutEnd.HasValue && (user.LockoutEnd > DateTimeOffset.UtcNow || user.LockoutEnd == DateTimeOffset.MaxValue)
                };
                userDtos.Add(dto);
            }
            var pagedList = new PagedList<UserDto>(userDtos, count, prm.PageNumber, prm.PageSize);

            Response.AddPaginationHeader(pagedList);

            return userDtos;
        }

        [HttpGet("get-user")]
        public async Task<ActionResult<UserDto>> GetUser([FromQuery] string userName)
        {
            var query = _userManager.Users.AsNoTracking().AsQueryable();

            var user = await query.FirstOrDefaultAsync(x => x.UserName == userName);

            var roles = await _userManager.GetRolesAsync(user);
            var dto = new UserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Gender = user.Gender.ToString(),
                ImgUrl = user.ImgUrl,
                Created = user.Created,
                Role = roles[0],
                Email = user.Email,
                IsLooked = user.LockoutEnd.HasValue && (user.LockoutEnd > DateTimeOffset.UtcNow || user.LockoutEnd == DateTimeOffset.MaxValue)
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromForm] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await CheckEmailExistAsync(dto.Email))
            {
                throw new BadRequestException("Email đã tồn tại");
            }

            if (await CheckUserNameExistAsync(dto.UserName))
            {
                throw new BadRequestException("UserName đã tồn tại");
            }

            var userToAdd = new AppUser
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email,
                Gender = Enum.Parse<Gender>(dto.Gender, true)
            };

            if (dto.ImgFile != null)
            {
                var resultUploadImage = await _cloudinaryService.AddImageAsync(dto.ImgFile);
                if (resultUploadImage.Error != null)
                    throw new BadRequestException(resultUploadImage.Error);

                userToAdd.PublicId = resultUploadImage.PublicId;
                userToAdd.ImgUrl = resultUploadImage.Url;
            }
            else
            {
                userToAdd.ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1735543269/user_pez7rf.webp";
            }

            var result = await _userManager.CreateAsync(userToAdd, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var resultAddRole = await _userManager.AddToRoleAsync(userToAdd, dto.Role);
            if (!resultAddRole.Succeeded)
            {
                var deleteResult = await _userManager.DeleteAsync(userToAdd);
                if (!deleteResult.Succeeded)
                {
                    throw new BadRequestException("Failed to rollback user creation. Please contact support.");
                }

                throw new BadRequestException("Thêm quyền thất bại. Người dùng đã bị xóa.");
            }


            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Gender = user.Gender.ToString(),
                ImgUrl = user.ImgUrl,
                Created = user.Created,
                Role = roles[0],
                Email = user.Email,
                IsLooked = user.LockoutEnd.HasValue && (user.LockoutEnd > DateTimeOffset.UtcNow || user.LockoutEnd == DateTimeOffset.MaxValue)
            };

            return CreatedAtAction(nameof(GetUser), new { userName = user.UserName }, userDto);
        }

        [HttpPut("update-information")]
        public async Task<ActionResult<UserDto>> UpdateInformation([FromQuery] string userName, [FromForm] UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy người dùng");
            }

            if (!string.Equals(user.Email, dto.Email, StringComparison.OrdinalIgnoreCase) &&
                await CheckEmailExistAsync(dto.Email))
            {
                throw new BadRequestException("Email đã tồn tại");
            }

            if (!string.Equals(user.UserName, dto.UserName, StringComparison.OrdinalIgnoreCase) &&
                await CheckUserNameExistAsync(dto.UserName))
            {
                throw new BadRequestException("UserName đã tồn tại");
            }

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.UserName = dto.UserName;
            user.Gender = Enum.Parse<Gender>(dto.Gender, true);

            if (dto.ImgFile != null)
            {
                var resultDelete = await _cloudinaryService.DeleteFileAsync(user.PublicId);
                if (resultDelete.Error != null)
                {
                    throw new BadRequestException(resultDelete.Error);
                }

                var resultUpload = await _cloudinaryService.AddImageAsync(dto.ImgFile);
                if (resultUpload.Error != null)
                {
                    throw new BadRequestException(resultUpload.Error);
                }

                user.PublicId = resultUpload.PublicId;
                user.ImgUrl = resultUpload.Url;
            }

            var updateUserResult = await _userManager.UpdateAsync(user);
            if (!updateUserResult.Succeeded)
            {
                throw new BadRequestException("Problem update user");
            }

            var updatedRoles = await _userManager.GetRolesAsync(user);
            var dtoResponse = new UserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Gender = user.Gender.ToString(),
                ImgUrl = user.ImgUrl,
                Created = user.Created,
                Role = updatedRoles.FirstOrDefault(),
                Email = user.Email,
                IsLooked = user.LockoutEnd.HasValue && (user.LockoutEnd > DateTimeOffset.UtcNow || user.LockoutEnd == DateTimeOffset.MaxValue)
            };

            return Ok(dtoResponse);
        }

        [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword([FromQuery] string userName, [FromBody] ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại.");
            }

            // check mật khẩu hiện tại có giống mật khẩu trong db ko 
            var passwordCheck = await _userManager.CheckPasswordAsync(user, dto.CurrentPassword);
            if (!passwordCheck)
            {
                throw new BadRequestException("Mật khẩu hiện tại không đúng.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.Password);
            if (!changePasswordResult.Succeeded)
            {
                throw new BadRequestException("Xảy ra lỗi khi đổi mật khẩu. Vui lòng thử lại sau");
            }

            return NoContent();
        }

        [HttpPut("change-role")]
        public async Task<ActionResult> ChangeRole([FromQuery] string userName, [FromBody] UpdateUserRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            // delete current role
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                throw new BadRequestException("Không thể loại bỏ quyền cũ của người dùng.");
            }

            // add new role
            var addRoleResult = await _userManager.AddToRoleAsync(user, dto.Role);
            if (!addRoleResult.Succeeded)
            {
                throw new BadRequestException("Không thể thêm quyền mới cho người dùng.");
            }

            return NoContent();

        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Failed to delete the user.");
            }

            
            return NoContent(); 
        }



        #region
        private async Task<bool> CheckEmailExistAsync(string text)
        {
            return await _userManager.Users.AnyAsync(u => u.Email.ToLower() == text.ToLower());
        }

        private async Task<bool> CheckUserNameExistAsync(string text)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName.ToLower() == text.ToLower());
        }

        #endregion
    }
}
