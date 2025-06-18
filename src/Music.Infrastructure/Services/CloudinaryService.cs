using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using KM.Application.Abstract;
using KM.Application.DTOs.Cloudinary;
using KM.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace KM.Infrastructure.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinaryConfig> config)
        {
            var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<FileUploadResult> AddFileAsync(IFormFile file)
        {
            var uploadResult = new RawUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    Folder = "k-music",
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null)
            {
                return new FileUploadResult
                {
                    Error = uploadResult.Error.Message,
                };
            }

            return new FileUploadResult
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString(),
                Error = null
            };
        }

        public async Task<FileUploadResult> AddImageAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    //Transformation = new Transformation(), // options: "fill", "limit", "scale"
                    Folder = "k-music"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }


            if (uploadResult.Error != null)
            {
                return new FileUploadResult
                {
                    Error = uploadResult.Error.Message
                };
            }


            return new FileUploadResult
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString(),
                Error = null
            };
        }

        public async Task<FileDeleteResult> DeleteFileAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            if (result.Error != null)
            {
                return new FileDeleteResult
                {
                    Error = result.Error.Message
                };
            }


            return new FileDeleteResult
            {
                Result = result.Result,
                Error = null
            };
        }
    }
}
