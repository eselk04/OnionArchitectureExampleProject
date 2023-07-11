using Microsoft.Extensions.DependencyInjection;
using OnionProject.Application.Abstractions.Storage;
using OnionProject.Application.Services;
using OnionProject.Infrastructure.Enums;
using OnionProject.Infrastructure.Services;
using OnionProject.Infrastructure.Storage;
using OnionProject.Infrastructure.Storage.Local;

namespace OnionProject.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection
        services)
    {
        services.AddScoped<IStorageService, StorageService>();
      

    }

    public static void AddStorage<T>(this IServiceCollection services) where T : class,IStorage
    {
        services.AddScoped<IStorage, T>();
    }

    public static void AddStorage(this IServiceCollection services, StorageType.storagetype storageType)
    {
        switch (storageType)
        {
            case StorageType.storagetype.Local:
                services.AddScoped<IStorage, LocalStorage>();
                break;
            case  StorageType.storagetype.Azure:
                break;
            case StorageType.storagetype.Aws:
                break;
            default:
                services.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}