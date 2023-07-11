using OnionProject.Application.Repositories;
using OnionProject.Application.Repositories.Product;
using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.Products;

public class ProductReadRepository : ReadRepository<Product> , IProductReadRepository
{
    public ProductReadRepository(PContext postgreContext) : base(postgreContext)
    {
    }
}