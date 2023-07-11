using Microsoft.EntityFrameworkCore;
using OnionProject.Domain.Entities;
using OnionProject.Domain.Entities.Common;
using File = OnionProject.Domain.Entities.File;

namespace OnionProject.Persistence.Context;

public class PContext : DbContext
{
    
    public DbSet<Product>  Products{ get; set; }
    public DbSet<Customer> Customers{ get; set; }
    public DbSet<Order> Orders{ get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<ProductImage> ProductImageFiles { get; set; }
    public  DbSet<InvoiceFile> InvoiceFiles { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"User ID =postgres ; Password = eselk00101; Host = localhost;Port =5432; Database = postgres");
    }


    public override int SaveChanges()
    {
      
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            
            ((BaseEntity)entityEntry.Entity).CreateTime = DateTimeOffset.UtcNow;

           
        }

        return base.SaveChanges();
    }

}