using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace OnionProject.Application.Repositories.File;

public interface IFileReadRepository : IReadRepository<Domain.Entities.File>
{
   
}