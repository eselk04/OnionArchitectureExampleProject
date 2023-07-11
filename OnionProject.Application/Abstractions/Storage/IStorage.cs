using Microsoft.AspNetCore.Http;

namespace OnionProject.Application.Abstractions.Storage;

public interface IStorage
{
    Task<List<(string fileName, string path )>> UploadAsync(string pathOrContainer , IFormFileCollection files);
    Task DeleteAsync(string pathOrContainerName ,string fileName);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string pathOrContainerName, string fileName);
    

}