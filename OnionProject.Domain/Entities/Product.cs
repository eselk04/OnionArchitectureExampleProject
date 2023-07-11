using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnionProject.Domain.Entities.Common;

namespace OnionProject.Domain.Entities;

public class Product : BaseEntity
{
    public int Stock { get; set; }
    public string Description { get; set; }  // Description of the product
    public decimal Price { get; set; }    // Price of the product
    public int Quantity { get; set; }     // Available quantity of the product
    
    public string Brand { get; set; }     // Brand or manufacturer of the product
    public string ImageUrl { get; set; }  // URL of th

}