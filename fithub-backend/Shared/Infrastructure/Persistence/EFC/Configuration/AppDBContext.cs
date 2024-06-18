using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>().ToTable("Product");
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(f => f.Name).IsRequired();
        builder.Entity<Product>().Property(f=>f.Description).IsRequired();
        builder.Entity<Product>().Property(f=>f.Price).IsRequired();
        builder.Entity<Product>().Property(f=>f.PhotoUrl).IsRequired();
        builder.Entity<Product>().Property(f=>f.CategoryId).IsRequired();
        
        builder.Entity<Category>().HasKey(f=>f.Id);
        builder.Entity<Category>().Property(f=>f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(f=>f.Name).IsRequired();
        
        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);

        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}