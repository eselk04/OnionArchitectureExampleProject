using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnionProject.Application.Repositories;
using OnionProject.Domain.Entities.Common;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository;

public class ReadRepository<T> : IRepository<T> , IReadRepository<T> where T : BaseEntity
{
    private readonly PContext _postgreContext;

    public ReadRepository(PContext postgreContext)
    {
        this._postgreContext = postgreContext;
        
    }


    public DbSet<T> Table => _postgreContext.Set<T>();
    public IQueryable<T> GetAll()
    {
        var a = Table;
        return a;
    }

    public IQueryable<T> GetWhere(Expression<Func<T,bool>> filter)
    {
        var a = Table.Where(filter);
        return a;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T,bool>> filter)
    {
       var a = await Table.SingleOrDefaultAsync(filter);
        return a;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var a = await Table.SingleOrDefaultAsync(p=>p.Id==id);
        return a;
    }

    public async Task<T> GetByNameAsync(string name)
    {
        var a = await Table.SingleOrDefaultAsync(p => p.Name == name);
        return a;
        
    }

    
}