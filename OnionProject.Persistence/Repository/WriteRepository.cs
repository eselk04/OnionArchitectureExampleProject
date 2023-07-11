using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnionProject.Application.Repositories;
using OnionProject.Domain.Entities;
using OnionProject.Domain.Entities.Common;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository;
public class WriteRepository<T> : IWriteRepository<T>, IRepository<T> where T : BaseEntity
{
    private readonly PContext _context;

    public WriteRepository(PContext context)
    {
        this._context = context;
    }

    protected WriteRepository()
    {
        throw new NotImplementedException();
    }

    public DbSet<T> Table => _context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
     
     var a = await Table.AddAsync(model);
     
     return a.State == EntityState.Added;


    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
      
        return true;
        
    }

    public bool Remove(T model)
    {
        var a = Table.Remove(model);

        return a.State == EntityState.Deleted;
        
    }

    public bool RemoveRange(List<T> datas)
    { Table.RemoveRange(datas);

        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model= await Table.FirstOrDefaultAsync(p => p.Id == Convert.ToInt16(id));
  
        return Remove(model);
    }

    public bool Update(T model)
    {
        var a = Table.Update(model);
   
        return a.State == EntityState.Modified;
       
    }

    public async Task<int> Save()
    {
         _context.SaveChanges();
        return 1;
    }
}