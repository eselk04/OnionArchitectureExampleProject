using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionProject.Application.Abstractions;
using OnionProject.Application.Repositories.File;
using OnionProject.Application.Repositories.Invoice;
using OnionProject.Application.Repositories.Product;
using OnionProject.Application.Repositories.ProductImage;
using OnionProject.Persistence.Concrete;
using OnionProject.Persistence.Context;
using OnionProject.Persistence.Repository.Files;
using OnionProject.Persistence.Repository.InvoiceFiles;
using OnionProject.Persistence.Repository.ProductImages;
using Microsoft.Extensions.Configuration;

using OnionProject.Persistence.Repository.Products;
using IProductImageWriteRepository = OnionProject.Persistence.Repository.ProductImages.ProductImageWriteRepository;

namespace OnionProject.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection
        services)
    {
        services.AddSingleton<IProductService,ProductService>();
        services.AddDbContext<PContext>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
        services.AddScoped<Application.Repositories.ProductImage.IProductImageWriteRepository,ProductImageWriteRepository>();
        services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
        services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
       


    }

}