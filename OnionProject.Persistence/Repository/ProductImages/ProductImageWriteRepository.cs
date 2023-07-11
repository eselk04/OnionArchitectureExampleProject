using OnionProject.Application.Repositories.ProductImage;
using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.ProductImages;

public class ProductImageWriteRepository : WriteRepository<ProductImage> , IProductImageWriteRepository
{
    public ProductImageWriteRepository(PContext context) : base(context)
    {
    }
}