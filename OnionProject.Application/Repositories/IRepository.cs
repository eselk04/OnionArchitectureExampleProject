using Microsoft.EntityFrameworkCore;

namespace OnionProject.Application.Repositories;

public interface IRepository<T> where  T : class
{
    public DbSet<T> Table { get;  }      
}