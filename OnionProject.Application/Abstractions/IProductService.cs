using OnionProject.Domain.Entities;

namespace OnionProject.Application.Abstractions;

public interface IProductService
{
    List<Product> GetProducts();
}