using KM.Application.DTOs.Cloudinary;
using Microsoft.AspNetCore.Http;

namespace KM.Application.Abstract
{
    public interface ICloudinaryService
    {
        Task<FileUploadResult> AddImageAsync(IFormFile file); // add img file (pgn, jpg,...)
        Task<FileDeleteResult> DeleteFileAsync(string publicId);
        Task<FileUploadResult> AddFileAsync(IFormFile file); // add audio file (mp3, ...)
    }
}
