using System.Linq.Expressions;
using OnionProject.Domain.Entities.Common;

namespace OnionProject.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    IQueryable<T> GetWhere(Expression<Func<T,bool>> filter);
    Task<T> GetSingleAsync(Expression<Func<T,bool>> filter);
    Task<T> GetByIdAsync(int id);
    Task<T> GetByNameAsync(string name);
    
} 