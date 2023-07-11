using OnionProject.Domain.Entities.Common;

namespace OnionProject.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Adress { get; set; }
    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }

}