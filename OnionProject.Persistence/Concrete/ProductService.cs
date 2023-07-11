using OnionProject.Application.Abstractions;
using OnionProject.Domain.Entities;

namespace OnionProject.Persistence.Concrete;

public class ProductService : IProductService
{
    public List<Product> GetProducts()
    {
        return new() {  };
    }
}