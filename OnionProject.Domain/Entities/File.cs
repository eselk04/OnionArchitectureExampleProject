using System.ComponentModel.DataAnnotations.Schema;
using OnionProject.Domain.Entities.Common;

namespace OnionProject.Domain.Entities;

public class File : BaseEntity
{
   
    public string Path { get; set; }
    public string Storage { get; set; }
    [NotMapped]
    public override DateTimeOffset UpdatedDate
    {
        get => base.UpdatedDate;
        set => base.UpdatedDate = value;
    }
}