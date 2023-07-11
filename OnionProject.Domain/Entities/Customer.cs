using OnionProject.Domain.Entities.Common;

namespace OnionProject.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Order> Orders;
}