using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.ProductImages;

public class IProductImageWriteRepository : WriteRepository<ProductImage> , Application.Repositories.ProductImage.IProductImageWriteRepository
{
    public IProductImageWriteRepository(PContext context) : base(context)
    {
    }
}