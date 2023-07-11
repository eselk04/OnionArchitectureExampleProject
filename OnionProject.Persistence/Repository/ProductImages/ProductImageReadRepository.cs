using OnionProject.Application.Repositories.ProductImage;
using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.ProductImages;

public class ProductImageReadRepository : ReadRepository<ProductImage>, IProductImageReadRepository
{
    public ProductImageReadRepository(PContext postgreContext) : base(postgreContext)
    {
    }
}