using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Domain.Interfaces;

public interface IFileStorageService
{
    void DeleteFile(string fileName);
    Task<string> EditFile(IFormFile file, string fileRoute);
    Task<string> SaveFile(IFormFile file);
}
