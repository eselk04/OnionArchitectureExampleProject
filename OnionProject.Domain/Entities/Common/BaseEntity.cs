using System.ComponentModel;

namespace OnionProject.Domain.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }
    
    public DateTimeOffset CreateTime { get; set; }
    public string Name { get; set; }
    public virtual DateTimeOffset UpdatedDate { get; set; }
    
    
    
}