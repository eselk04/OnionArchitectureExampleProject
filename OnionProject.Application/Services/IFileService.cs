using Microsoft.AspNetCore.Http;

namespace OnionProject.Application.Services;

public interface IFileService
{
   

    Task<string> FileRenameAsync(string fileName );
  
}