using Microsoft.AspNetCore.Http;
using Music.Core.DTOs.Cloudinary;

namespace Music.Core.Interfaces
{
    public interface ICloudinaryService
    {
        Task<FileUploadResult> AddImageAsync(IFormFile file); // add img file (pgn, jpg,...)
        Task<FileDeleteResult> DeleteFileAsync(string publicId);
        Task<FileUploadResult> AddFileAsync(IFormFile file); // add audio file (mp3, ...)
    }
}
