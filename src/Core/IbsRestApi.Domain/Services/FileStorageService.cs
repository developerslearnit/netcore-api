using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace IbsRestApi.Domain.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IConfiguration _config;
    IWebHostEnvironment _env;
    public FileStorageService(IConfiguration config, IWebHostEnvironment env)
    {
        _config = config;
        _env = env;
    }

    public void DeleteFile(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            var folder = _config.GetValue<string>("ImageFolder");
            var _rootPath = _env.ContentRootPath;
            var fileDirectory = Path.Combine(_rootPath, folder, fileName);

            if (File.Exists(fileDirectory))
                File.Delete(fileDirectory);
        }
    }

    public async Task<string> EditFile(IFormFile file, string fileRoute)
    {
        DeleteFile(fileRoute);
        return await SaveFile(file);
    }

    public async Task<string> SaveFile(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var folder = _config.GetValue<string>("ImageFolder");

        var _rootPath = _env.ContentRootPath;
        var path = Path.Combine(_rootPath, folder);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var route = Path.Combine(path, fileName);
        using (var ms = new MemoryStream())
        {
            await file.CopyToAsync(ms);
            var content = ms.ToArray();
            await File.WriteAllBytesAsync(route, content);
        }
        //var routeForDB = Path.Combine(folder,fileName).Replace("\\", "/");
        return fileName;
    }
}
