using OnionProject.Application.Repositories;
using OnionProject.Application.Repositories.Product;
using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.Products;

public class ProductWriteRepository : WriteRepository<Product> , IProductWriteRepository
{
    public ProductWriteRepository(PContext postgreContext) : base(postgreContext)
    {
    }
}