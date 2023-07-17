namespace OnionProject.Application.Abstractions.Storage;

public interface IStorageService : IStorage
{
    public string StorageName { get; set; }
}