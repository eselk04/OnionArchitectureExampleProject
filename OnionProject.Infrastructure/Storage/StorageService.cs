using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionProject.Application.Abstractions.Storage;

namespace OnionProject.Infrastructure.Storage;

public class StorageService : IStorageService
{
    private readonly IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage = storage;
    }

    public Task<List<(string fileName, string path)>> UploadAsync(string pathOrContainer, IFormFileCollection files) =>
        _storage.UploadAsync(pathOrContainer, files);

    public Task DeleteAsync(string pathOrContainerName, string fileName) =>
        _storage.DeleteAsync(pathOrContainerName, fileName);

    public List<string> GetFiles(string pathOrContainerName) =>
        _storage.GetFiles(pathOrContainerName);

    public bool HasFile(string pathOrContainerName, string fileName) =>
        _storage.HasFile(pathOrContainerName, fileName);

    public string StorageName
    {
        get  =>  _storage.GetType().Name;
        set { }
    }
}